using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	public class FilmTypesController: Controller
	{
		private readonly IFilmTypeService _filmTypeService;

		public FilmTypesController(IFilmTypeService filmTypeService)
		{
			_filmTypeService = filmTypeService;
		}

		[HttpGet("FilmTypes")]
		public async  Task<IActionResult> GetFilmTypes()
		{
			try
			{
				return Ok(await _filmTypeService.GetFilmTypesAsync());
			}
			catch (Exception ex)
			{
				return BadRequest("Ошибка во время получения типов фильмов");
			}
		}
	}
}
