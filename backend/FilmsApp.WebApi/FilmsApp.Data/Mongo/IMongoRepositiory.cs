
using MongoDB.Driver;

namespace FilmsApp.Data.Mongo
{
	public interface IMongoRepositiory
	{
		Task CreateFilmAsync(MongoFilm film);
		Task<MongoFilm> GetFilmByIdAsync(int id);
		Task RemoveAsync(int id);
		Task UpdateFilmAsync(MongoFilm film);
		Task<List<MongoFilm>> FindFilmByFilterAsync(FilterDefinition<MongoFilm> filter);
	}
}