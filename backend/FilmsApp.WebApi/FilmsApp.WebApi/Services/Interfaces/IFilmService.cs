using FilmsApp.Data.Entities;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface IFilmService
	{

		public Task<MongoFilm[]> SearchFilmsAsync(string filmName, int count = 20, int offset = 0);
		public Task<FilmDTO> GetFilmAsync(int id);
		public Task<int> CreateFilmAsync (CreateFilmDTO createFilmDTO);
	}
}
