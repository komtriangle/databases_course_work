using FilmsApp.Data;
using FilmsApp.Data.Entities;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FilmsApp.Data.Mapper;
using FilmsApp.WebApi.DTO.Extensions;

namespace FilmsApp.WebApi.Services
{
	public class FilmService : IFilmService
	{
		private readonly IMongoRepositiory _mongoRepositiory;
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;
		private readonly AppSettings _appSettings;
		private readonly ILogger<FilmService> _logger;

		public FilmService (IMongoRepositiory mongoRepositiory,
			IDbContextFactory<FilmsContext> dbContextFactory,
			IOptions<AppSettings> appSettingsOptions,
			ILogger<FilmService> logger)
		{
			_mongoRepositiory = mongoRepositiory ??
				throw new ArgumentNullException(nameof(mongoRepositiory));
			_dbContextFactory = dbContextFactory ??
				throw new ArgumentNullException(nameof(_dbContextFactory));
			_appSettings = appSettingsOptions?.Value ??
				throw new ArgumentNullException(nameof(appSettingsOptions));
			_logger = logger ??
				throw new ArgumentNullException(nameof(logger));
		}

		public async Task<int> CreateFilmAsync (CreateFilmDTO createFilmDTO)
		{
			using (FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
			{
				if (string.IsNullOrWhiteSpace(createFilmDTO.Name))
				{
					throw new Exception("Фильм должен иметь название");
				}

				if (createFilmDTO.Length <= 0)
				{
					throw new Exception("Длина фильма должна быть больше 0");
				}

				FilmType filmType = await context.FilmType.FindAsync(createFilmDTO.FilmTypeId);

				if (filmType == null)
				{
					throw new Exception($"Передан несуществующий Id типа фильма: {filmType}");
				}

				if (!createFilmDTO.CountriesIds.Any())
				{
					throw new Exception("Должна быть передана хотя бы одна страна");
				}

				if (string.IsNullOrWhiteSpace(createFilmDTO.TrailerFileName))
				{
					throw new Exception("Должно быть передано название трейлера");
				}

				if (!ValidateTrailer(createFilmDTO.TrailerFileName))
				{
					throw new Exception("Некорректное значение нзавания файла трейлера");
				}

				List<Country> countries = new List<Country>();

				foreach (int countryId in createFilmDTO.CountriesIds)
				{
					Country country = await context.Countries.FindAsync(countryId);

					if (country == null)
					{
						throw new Exception($"Передан несущесвующий Id страны: {countryId}");
					}

					countries.Add(country);
				}


				if (!createFilmDTO.GenresIds.Any())
				{
					throw new Exception("Должен быть передан хотя бы один жанр");
				}

				List<Genre> genres = new List<Genre>();

				foreach (int genreId in createFilmDTO.GenresIds)
				{
					Genre genre = await context.Genres.FindAsync(genreId);

					if (genre == null)
					{
						throw new Exception($"Передан несуществующий Id жанра: {genreId}");
					}

					genres.Add(genre);
				}

				List<FilmPerson> personFilms = new List<FilmPerson>();

				foreach (var personFilm in createFilmDTO.PersonDTO)
				{
					Person person = await context.People.FindAsync(personFilm.PersonId);

					if (person == null)
					{
						throw new Exception($"Передан несуществующий Id человека:{personFilm.PersonId}");
					}

					Speciality speciality = await context.Specialities.FindAsync(personFilm.SpecialityId);

					if (speciality == null)
					{
						throw new Exception($"Передан несуществующий Id специальности:{personFilm.PersonId}");
					}

					personFilms.Add(new FilmPerson()
					{
						Person = person,
						Speciality = speciality
					});
				}

				MediaFileExtension trailerExtension = await context.MediaFileExtensions.FirstOrDefaultAsync(
					mf => mf.Extension == GetExtension(createFilmDTO.TrailerFileName));

				if (trailerExtension == null)
				{
					throw new Exception($"Не найдено расширение файла для трейлера: {createFilmDTO.TrailerFileName}");
				}

				using var transaction = context.Database.BeginTransaction();

				FilmMediaFile filmTrailer = new FilmMediaFile()
				{
					MediaFile = new MediaFile()
					{ 
						Path = createFilmDTO.TrailerFileName,
						MediaFileExtension = trailerExtension
					},
					Type = 3,
				};

				Film film = new Film()
				{
					Name = createFilmDTO.Name,
					EngName = createFilmDTO.EngName,
					Description = createFilmDTO.Description,
					YearOfRelease = createFilmDTO.YearOfRelease,
					FilmType = filmType,
					Genres = genres
						.Select(genre => new FilmGenre()
						{
							Genre = genre
						})
						.ToArray(),
					Countries = countries
						.Select(country => new FilmCountry()
						{
							CountryId = country.Id
						})
						.ToArray(),
					People = personFilms,
					MediaFiles = new List<FilmMediaFile>()
					{
						filmTrailer
					}
				};

				await context.Films.AddAsync(film);

				try
				{
					await context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка во время сохранения фильма в Postgres");
					throw new Exception("Ошибка во время сохранения фильма");
				}

				MongoFilm mongoFilm = film.ToMongoModel();

				try
				{
					await _mongoRepositiory.CreateFilmAsync(mongoFilm);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка во время сохранения фильма в Mongo");
					await transaction.RollbackAsync();
					throw new Exception("Ошибка во время сохранения фильма");
				}

				await transaction.CommitAsync();

				return film.Id;
			}
		}

		public async Task<MongoFilm[]> SearchFilmsAsync (string searchQuery, int count = 20, int offset = 0)
		{
			List<MongoFilm> films = new List<MongoFilm>();

			if (string.IsNullOrEmpty(searchQuery))
			{
				films = await _mongoRepositiory.FindFilmByFilterAsync(EmptyFind(count, offset));
				return films.ToArray();
			}

			try
			{
				films.AddRange(await _mongoRepositiory.FindFilmByFilterAsync(FindByName(searchQuery)));

				if (films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				if (films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				if (films.Count < count + offset)
				{
					List<MongoFilm> filmsToAdd = await _mongoRepositiory.FindFilmByFilterAsync(FindByStartOfName(searchQuery));
					filmsToAdd = filmsToAdd.Where(x => !films.Any(y => y.Id == x.Id)).ToList();
					films.AddRange(filmsToAdd);
				}

				return films.Skip(offset).Take(count).ToArray();
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		public async Task<FilmDTO> GetFilmAsync (int id)
		{
			Film film;
			using (FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
			{
				film = await context.Films
					.FirstAsync(x => x.Id == id);

				return film?.ToDTO();
			}

		}

		private static FilterDefinition<MongoFilm> EmptyFind (int count, int offset)
		{
			var builder = Builders<MongoFilm>.Filter;
			var result = builder.And(builder.Gt(x => x.Id, offset), builder.Lt(x => x.Id, offset + count));
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByName (string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Eq(f => f.Name, searchQuery);
			return result;
		}

		private static FilterDefinition<MongoFilm> FindByStartOfName (string searchQuery)
		{
			var result = Builders<MongoFilm>.Filter.Where(f => f.Name.StartsWith(searchQuery));
			return result;
		}

		private string GetExtension (string fileName)
		{
			string trailerPath = Path.Combine(_appSettings.MediaContnetDirectory, fileName);

			if (!File.Exists(trailerPath))
			{
				throw new Exception($"Файл: {fileName} не найден");
			}

			return Path.GetExtension(trailerPath);
		}

		private bool ValidateTrailer (string fileName)
		{
			string trailerPath = Path.Combine(_appSettings.MediaContnetDirectory, fileName);

			if (!File.Exists(trailerPath))
			{
				return false;
			}

			string fileExtension = Path.GetExtension(trailerPath);

			return fileExtension == ".mp4" || fileExtension == ".mov";

		}

	}
}
