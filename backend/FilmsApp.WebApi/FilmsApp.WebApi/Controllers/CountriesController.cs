using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FilmsApp.WebApi.Exceptions;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	public class CountriesController : Controller
	{

		private readonly ICountryService _countryService;
		private readonly ILogger<CountriesController> _logger;

		public CountriesController(ICountryService countryService,
			ILogger<CountriesController> logger)
		{
			_countryService = countryService;
			_logger = logger;
		}


		[HttpGet("GetCountries")]
		public async Task<IActionResult> GetCountries(string searchQuery, int count = 10, int offset = 0)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на получение стран");

			try
			{
				return Ok(await _countryService.GetCountriesAsync(searchQuery, count, offset));
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время получения фильмов");
				return BadRequest("Ошибка при выполнении запроса");
			}
		}
	}
}
