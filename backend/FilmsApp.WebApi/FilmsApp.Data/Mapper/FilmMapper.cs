using FilmsApp.Data.Entities;
using FilmsApp.Data.Mongo;

namespace FilmsApp.Data.Mapper
{
	public static class FilmMapper
	{
		public static MongoFilm ToMongoModel(this Film film)
		{
			MongoFilm mongoFilm = new MongoFilm
			{
				Id = film.Id,
				Name = film.Name,
				Description = film.Description,
				EngName = film.EngName,
				Length = film.Length,
				Rating = film.Rating,
				YearOfRelease = film.YearOfRelease
			};

			mongoFilm.FilmType = film.FilmType?.Name;

		    mongoFilm.Countries = film.Countries
				.Select(c => c.Country?.Name)
				.Where(c => c != null)
				.ToArray();

			mongoFilm.Genres = film.Genres
				.Select(g => g.Genre?.Name)
				.Where(g => g != null)
				.ToArray();

			mongoFilm.Persons = film.People
				.Take(5)
				.OrderByDescending(p => p.Person.Films.Count)
				.Select(person => new MongoFilmPerson
				{
					Name = person.Person?.Name,
					Speciality = person.Speciality?.Name
				})
				.Where(p => p.Name != null && p.Speciality != null)
				.ToArray();

			mongoFilm.PosterUrl = film.MediaFiles
				.Where(x => x.Type == 1)
				.FirstOrDefault()
				?.MediaFile?.Path;


			return mongoFilm;
		}
	}
}
