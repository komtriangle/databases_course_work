using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface IFilmTypeService
	{
		Task<IEnumerable<FilmTypeDTO>> GetFilmTypesAsync();
	}
}
