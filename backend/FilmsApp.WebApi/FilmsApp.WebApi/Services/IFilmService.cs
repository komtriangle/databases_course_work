using FilmsApp.Data.Mongo;

namespace FilmsApp.WebApi.Services
{
	public interface IFilmService
	{
		public Task<MongoFilm> GetFilmAsync(int id);

		public Task<MongoFilm[]> SearchFilms(string filmName, int count = 20, int offset = 0);
	}
}
