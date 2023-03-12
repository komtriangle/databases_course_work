using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface ICountryService
	{
		Task<IEnumerable<CountryDTO>> GetCountriesAsync(string searchQuery, int count, int offset);
	}
}
