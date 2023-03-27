using FilmsApp.Data;
using FilmsApp.Data.Mapper;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
		public FilmsController(
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
		public async Task<IActionResult> SearchFilms(string? searchQuery = null, int count = 20, int offset = 0)
		{
			return  Json(await _filmService.SearchFilms(searchQuery, count, offset));
		}

		[HttpGet("GetById{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]

		public async Task<IActionResult> GetFilm(int id)
		{
			try
			{
				FilmDTO film = await _filmService.GetFilmAsync(id);

				if(film == null)
				{
					return NotFound($"Фильм с Id: {id} не найден");
				}

				return Json(film);
			}
			catch(Exception ex)
			{
				return BadRequest("Ошибка во время поиска фильма");
			}

		}


		[HttpGet("FillMongo")]
		public async Task<IActionResult> FillMongo()
		{
			using(FilmsContext context = _dbContextFactory.CreateDbContext())
			{
				var films = context.Films.ToArray().Select(x => x.ToMongoModel());

				foreach(var film in films)
				{
					await _mongoRepositiory.CreateFilmAsync(film);
					Console.WriteLine(film.Name);
				}
			}

			return Json(1);

		}

		[HttpPost("CreateFilm")]
		public async Task<IActionResult> CreateFilm([FromBody] CreateFilmDTO film)
		{
			try
			{
				return Ok(await _filmService.CreateFilm(film));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpPost("DownloadVideo")]
		[RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
		[DisableRequestSizeLimit]
		public async Task<IActionResult> PostVideo([FromForm] IFormFile file)
		{
			try
			{
				if(file == null || file.Length == 0 || !file.ContentType.Contains("video"))
				{
					return BadRequest("Некорректный файл");
				}

				var filePath = $"{Guid.NewGuid()}-{file.FileName}";
				using(var stream = new FileStream(Path.Combine(_appSettings.MediaContnetDirectory, filePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				return Ok(filePath);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, $"Ошибка во время загрузки видео");
				return BadRequest("Ошибка во время загрузка видео");
			}

		}
	}
}
