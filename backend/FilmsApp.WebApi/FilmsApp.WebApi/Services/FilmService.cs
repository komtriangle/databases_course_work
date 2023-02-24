using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Exceptions;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace FilmsApp.WebApi.Services
{
	public class FilmService : IFilmService
	{
		private readonly IMongoRepositiory _mongoRepositiory;

		public FilmService(IMongoRepositiory mongoRepositiory)
		{
			_mongoRepositiory = mongoRepositiory ??
				throw new ArgumentNullException(nameof(mongoRepositiory));
		}
		public async Task<MongoFilm> GetFilmAsync(int id)
		{
			MongoFilm film = null;

			try
			{
			    film = await _mongoRepositiory.GetFilmByIdAsync(id);
			}
			catch (Exception ex)
			{
				throw;
			}

			if(film == null)
			{
				throw new FilmNotFoundException();
			}

			return film;

		}

		public async Task<MongoFilm[]> SearchFilms(string searchQuery, int count = 20, int offset = 0)
		{
			List<MongoFilm> films = new List<MongoFilm>();


			try
			{
				films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByName(searchQuery)));

				if(films.Count < count + offset)
				{
					films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery)));
				}

				if(films.Count < count + offset)
				{
					films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByContaintOfName(searchQuery)));
				}

				if(films.Count < count + offset)
				{
					films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByContaintOfDescription(searchQuery)));
				}

				return films.Skip(offset).Take(count).ToArray();
			}
			catch(Exception ex)
			{
				throw;
			}

			
		}

		private static FilterDefinition<MongoFilm> FindByName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Eq(f => f.Name.ToLower(), searchQuery?.ToLower());
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByStartOfName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Name.ToLower().StartsWith(searchQuery.ToLower()));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByContaintOfName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Name.ToLower().Contains(searchQuery.ToLower()));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByContaintOfDescription(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Description.ToLower().Contains(searchQuery.ToLower()));
			return result;
		}
	}
}
