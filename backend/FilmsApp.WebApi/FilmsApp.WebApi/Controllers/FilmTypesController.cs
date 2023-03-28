using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FilmsApp.WebApi.Exceptions;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	public class FilmTypesController: Controller
	{
		private readonly IFilmTypeService _filmTypeService;
		private readonly ILogger<FilmTypesController> _logger;

		public FilmTypesController(IFilmTypeService filmTypeService,
			ILogger<FilmTypesController> logger)
		{
			_filmTypeService = filmTypeService;
			_logger = logger;
		}

		[HttpGet("FilmTypes")]
		public async  Task<IActionResult> GetFilmTypes()
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на получение списка типов фильмов");
			try
			{
				return Ok(await _filmTypeService.GetFilmTypesAsync());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время получения списка типов фильмов");
				return BadRequest("Ошибка во время получения типов фильмов");
			}
		}
	}
}
