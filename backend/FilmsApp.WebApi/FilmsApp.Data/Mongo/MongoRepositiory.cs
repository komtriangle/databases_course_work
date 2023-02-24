using FilmsApp.Data.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace FilmsApp.Data.Mongo
{
	public class MongoRepositiory : IMongoRepositiory
	{

		private readonly MongoClient _mongoClient;
		private readonly IMongoCollection<MongoFilm> _filmCollection;

		public MongoRepositiory(IOptions<MongoConfig> mongoConfig)
		{
			_mongoClient = new MongoClient(mongoConfig.Value.ConnectionString);

			IMongoDatabase? filmsDatabase = _mongoClient.GetDatabase(mongoConfig.Value.Database);

			if(filmsDatabase == null)
			{
				throw new Exception($"База данных {mongoConfig.Value.Database} не найдена " +
					$"в монго");
			}

			_filmCollection = filmsDatabase.GetCollection<MongoFilm>(mongoConfig.Value.FilmsCollection);

			if(_filmCollection == null)
			{
				throw new Exception($"Коллекция {mongoConfig.Value.FilmsCollection} не найдена" +
					$" в монго");
			}
		}

		public async Task<MongoFilm> GetFilmByIdAsync(int id)
		{
			return await _filmCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task CreateFilmAsync(MongoFilm film)
		{
			await _filmCollection.InsertOneAsync(film);
		}

		public async Task UpdateFilmAsync(MongoFilm film)
		{
			await _filmCollection.ReplaceOneAsync(x => x.Id == film.Id, film);
		}

		public async Task RemoveAsync(int id)
		{
			await _filmCollection.DeleteOneAsync(x => x.Id == id);
		}

		public async Task<List<MongoFilm>> FindFilmByFilterAsync(FilterDefinition<MongoFilm> filter)
		{
			return (await _filmCollection.FindAsync(filter)).ToList();
		}
	}
}
