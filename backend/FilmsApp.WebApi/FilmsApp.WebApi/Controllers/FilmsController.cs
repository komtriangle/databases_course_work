using FilmsApp.Data;
using FilmsApp.Data.Mapper;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FilmsApp.WebApi.Exceptions;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	public class FilmsController : Controller
	{

		private readonly IFilmService _filmService;
		private readonly IMongoRepositiory _mongoRepositiory;
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;
		private readonly AppSettings _appSettings;
		private readonly ILogger<FilmsController> _logger;
		public FilmsController (
			IFilmService filmService,
			IMongoRepositiory mongoRepositiory,
			IDbContextFactory<FilmsContext> dbContextFactory,
			IOptions<AppSettings> settingsOptions,
			ILogger<FilmsController> logger)
		{
			_filmService = filmService ??
				throw new ArgumentNullException(nameof(filmService));

			_appSettings = settingsOptions.Value;

			_mongoRepositiory = mongoRepositiory;
			_dbContextFactory = dbContextFactory;
			_logger = logger;
		}


		[HttpGet("SearchFilms")]
		public async Task<IActionResult> SearchFilms (string? searchQuery = null, int count = 20, int offset = 0)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на поиска фильмов");
			try
			{
				return Json(await _filmService.SearchFilmsAsync(searchQuery, count, offset));
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время поиска фильмов");
				return BadRequest("Оштбка во время поиска фильмов");
			}
		}

		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]

		public async Task<IActionResult> GetFilm (int id)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на получение фильма с Id: {id}");
			
			try
			{
				FilmDTO film = await _filmService.GetFilmAsync(id);

				if (film == null)
				{
					return NotFound($"Фильм с Id: {id} не найден");
				}

				return Json(film);
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex, $"Ошибка во время поиска фильма с Id: {id}");
				return BadRequest("Ошибка во время поиска фильма");
			}

		}


		[HttpGet("FillMongo")]
		public async Task<IActionResult> FillMongo ()
		{
			using (FilmsContext context = _dbContextFactory.CreateDbContext())
			{
				var films = context.Films.ToArray().Select(x => x.ToMongoModel());

				foreach (var film in films)
				{
					await _mongoRepositiory.CreateFilmAsync(film);
					Console.WriteLine(film.Name);
				}
			}

			return Json(1);

		}

		[HttpPost("CreateFilm")]
		public async Task<IActionResult> CreateFilm ([FromBody] CreateFilmDTO film)
		{
			_logger.LogInformation($"Запрос на создание фильма от пользователя: {User.GetUserName()}");

			try
			{
				return Ok(await _filmService.CreateFilmAsync(film));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время создания фильма");
				return BadRequest(ex.Message);
			}

		}

		[HttpPost("DownloadVideo")]
		[RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
		[DisableRequestSizeLimit]
		public async Task<IActionResult> PostVideo ([FromForm] IFormFile file)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на загрузку видео");

			try
			{
				if (file == null || file.Length == 0 || !file.ContentType.Contains("video"))
				{
					return BadRequest("Некорректный файл");
				}

				var filePath = $"{Guid.NewGuid()}-{file.FileName}";
				using (var stream = new FileStream(Path.Combine(_appSettings.MediaContnetDirectory,"trailers", filePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				return Ok(filePath);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Ошибка во время загрузки видео");
				return BadRequest("Ошибка во время загрузка видео");
			}

		}
	}
}
