using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	public class CountriesController : Controller
	{

		private readonly ICountryService _countryService;

		public CountriesController(ICountryService countryService)
		{
			_countryService = countryService;
		}


		[HttpGet("GetCountries")]
		public async Task<IActionResult> GetCountries(string searchQuery, int count = 10, int offset = 0)
		{
			try
			{
				return Ok(await _countryService.GetCountriesAsync(searchQuery, count, offset));
			}
			catch(Exception ex)
			{
				return BadRequest("Ошибка при выполнении запроса");
			}
		}
	}
}
