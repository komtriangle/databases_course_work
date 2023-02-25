using FilmsApp.Data;
using FilmsApp.Data.Entities;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.DTO.Extensions;
using FilmsApp.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FilmsApp.WebApi.Services
{
	public class FilmService : IFilmService
	{
		private readonly IMongoRepositiory _mongoRepositiory;
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public FilmService(IMongoRepositiory mongoRepositiory,
			IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_mongoRepositiory = mongoRepositiory ??
				throw new ArgumentNullException(nameof(mongoRepositiory));
			_dbContextFactory = dbContextFactory ??
				throw new ArgumentNullException(nameof(_dbContextFactory));
		}

		public async Task<MongoFilm[]> SearchFilms(string searchQuery, int count = 20, int offset = 0)
		{
			List<MongoFilm> films = new List<MongoFilm>();

			if(string.IsNullOrEmpty(searchQuery))
			{
				films = await _mongoRepositiory.FindFilmByFilterAsync(EmptyFind(count, offset));
				return films.ToArray();
			}

			try
			{
				films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByName(searchQuery)));

				if(films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				if(films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				if(films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				return films.Skip(offset).Take(count).ToArray();
			}
			catch(Exception ex)
			{
				throw;
			}

		}

		public async Task<FilmDTO> GetFilmAsync(int id)
		{
			Film film;
			using(FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
			{
				film = await context.Films
					.FirstAsync(x => x.Id == id);

				return film?.ToDTO();
			}

		}

		private static FilterDefinition<MongoFilm> EmptyFind(int count, int offset)
		{
			var builder = Builders<MongoFilm>.Filter;
			var result = builder.And(builder.Gt(x => x.Id, offset), builder.Lt(x => x.Id, offset+count));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Eq(f => f.Name, searchQuery);
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByStartOfName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Name.StartsWith(searchQuery));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByContaintOfName(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Name.Contains(searchQuery));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByContaintOfDescription(string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Description.Contains(searchQuery));
			return result;
		}
	}
}
