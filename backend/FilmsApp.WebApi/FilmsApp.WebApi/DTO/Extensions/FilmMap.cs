using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class FilmMap
	{
		public static FilmDTO ToDTO(this Film film)
		{
			return new FilmDTO
			{
				Id = film.Id,
				Name = film.Name,
				EngName = film.EngName,
				Description = film.Description,
				Rating = film.Rating,
				Length = film.Length,
				YearOfRelease = film.YearOfRelease,
				Genres = film.Genres
					.Select(x => x.Genre?.ToDTO())
					.Where(x => x != null)
					.ToArray(),
				Countries = film.Countries
					.Select(x => x.Country?.ToDTO())
					.Where(x => x != null)
					.ToArray(),
				FilmType = film.FilmType.ToDTO(),
				MediaFiles = film.MediaFiles
					.Select(x => x?.ToDTO())
					.Where(x => x != null)
					.ToArray(),
				FilmPeople = film.People?
				.Select(x => x?.ToDTO())
				.Where(x => x != null)
				.ToArray(),
				Comments = film.Comments
				.Select(x => x?.ToDTO())
				.Where (x => x != null)
				.ToArray()
			};
		}
	}
}
