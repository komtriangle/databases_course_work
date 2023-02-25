using FilmsApp.Data.Entities;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services
{
	public interface IFilmService
	{

		public Task<MongoFilm[]> SearchFilms(string filmName, int count = 20, int offset = 0);
		public Task<FilmDTO> GetFilmAsync(int id);
	}
}
