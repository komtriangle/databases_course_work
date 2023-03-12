using FilmsApp.Data;
using FilmsApp.Data.Mapper;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services;
using FilmsApp.WebApi.Services.Interfaces;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FilmsApp.WebApi.Controllers
{
	//[Authorize]
	[Route("[controller]")]
	public class FilmsController : Controller
	{

		private readonly IFilmService _filmService;
		private readonly IMongoRepositiory mongoRepositiory;
		private readonly IDbContextFactory<FilmsContext> dbContextFactory;
		private readonly AppSettings _appSettings;
		public FilmsController(
			IFilmService filmService, 
			IMongoRepositiory mongoRepositiory, 
			IDbContextFactory<FilmsContext> dbContextFactory,
			IOptions<AppSettings> settingsOptions)
		{
			_filmService = filmService ??
				throw new ArgumentNullException(nameof(filmService));

			_appSettings = settingsOptions.Value;

			this.mongoRepositiory = mongoRepositiory;
			this.dbContextFactory = dbContextFactory;
		}

		[HttpGet("SearchFilms")]
		public async Task<IActionResult> SearchFilms(string? searchQuery = null, int count = 20, int offset =0)
		{
			//GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

			//// Change this to your google client ID
			//settings.Audience = new List<string>() { "1006300932308-v47i976nval32vprp2586355p4n4fuib.apps.googleusercontent.com" };

			//GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync("eyJhbGciOiJSUzI1NiIsImtpZCI6IjI1NWNjYTZlYzI4MTA2MDJkODBiZWM4OWU0NTZjNDQ5NWQ3NDE4YmIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiIxMDA2MzAwOTMyMzA4LXJxdW9pZ2dwaDdpdWJkaDU5YWd2aDNsZjhqNW0zMmkwLmFwcHMuZ29vZ2xldXNlcmNvbnRlbnQuY29tIiwiYXVkIjoiMTAwNjMwMDkzMjMwOC12NDdpOTc2bnZhbDMydnBycDI1ODYzNTVwNG40ZnVpYi5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsInN1YiI6IjEwMDMyNDA2NDc3MDk5ODIxODA1NyIsImVtYWlsIjoia2FyYm9ld0BnbWFpbC5jb20iLCJlbWFpbF92ZXJpZmllZCI6dHJ1ZSwiYXRfaGFzaCI6Im1BUDBWb2dTVF9wTmoxNE9ua1FaRFEiLCJub25jZSI6IkJGNjN4d01nNEw5LWRlYU8wYlhRVjdUdmxJQ0x5LTVkRmprY0x5bDR4S3MiLCJuYW1lIjoiTWFpbiBJbnNhbmUiLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tL2EvQUdObXl4WnIzbnJTM1BJM1pFQmNrb0IzaS1HR205eUxQcmp4bGVweEZwWlI9czk2LWMiLCJnaXZlbl9uYW1lIjoiTWFpbiIsImZhbWlseV9uYW1lIjoiSW5zYW5lIiwibG9jYWxlIjoicnUiLCJpYXQiOjE2Nzc5NDY5MDksImV4cCI6MTY3Nzk1MDUwOX0.LId-WgBcJDggBayogmYO1LWZIZtI4Ms4j56dxdo8TwTfDos7W9v9wEZYbFFoslT0Rqg1uh68cMCATVMNe9pKkX9JJglKZMvF97wWPeTeLAwj2l5uvQrc_X8M840d40U9cavY-47QNfXLc3zm1JGhu3oO-9SSS5AGS427XiW5MqlSvKSSKkQDDWd1cwsxtO2f0VGP2FqKK9TIZ9XlhKzkTu3FeEmTanA46iSg5HFREpdd0ypIPrBtKklVRis-I9ecsTBlicFP0tnWGpJrqS-qUBctiZZAyYGASJ7XFqWwMwJjVSzXQMwHKs3cMmGzbBb_ZlrW5EzePLPnLKBbLl38-Q", settings).Result;
			////return Ok(new { AuthToken = _jwtGenerator.CreateUserAuthToken(payload.Email) });

			return Json(await _filmService.SearchFilms(searchQuery, count, offset));
		}

		[HttpGet("GetById{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
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
			using(FilmsContext context = dbContextFactory.CreateDbContext())
			{
				var films = context.Films.ToArray().Select(x => x.ToMongoModel());

				foreach(var film in films)
				{
					await mongoRepositiory.CreateFilmAsync(film);
					Console.WriteLine(film.Name);
				}
			}

			return Json(1);
			
		}

		[HttpPost("CreateFilm")]
		public  IActionResult CreateFilm([FromBody] CreateFilmDTO film)
		{

			return Ok("ОК");
		}

		[HttpPost("DownloadVideo")]
		[RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
		[DisableRequestSizeLimit]
		public async Task<IActionResult> PostVideo([FromForm] IFormFile file)
		{
			try
			{
				// video - это объект класса, который вы ожидаете от клиента, содержащий информацию о видео
				// file - это файл (видео), который вы ожидаете от клиента

				// проверяем, что файл не пустой и имеет допустимый тип
				if(file == null || file.Length == 0 || !file.ContentType.Contains("video"))
				{
					return BadRequest("Invalid file");
				}

				// сохраняем файл в хранилище, используя любую библиотеку для работы с файлами
				var filePath =  file.FileName;
				using(var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				// сохраняем информацию о видео в базу данных
				// video - это объект класса, содержащий информацию о видео, который мы получили от клиента
				// filePath - это путь к файлу, который мы сохранили на диске
				// используйте свой собственный код для сохранения информации о видео в базу данных
				// например, Entity Framework или ADO.NET
				// ...

				return Ok("Video uploaded successfully");
			}
			catch(Exception ex)
			{

			}

			return Ok();
		}
	}
}
