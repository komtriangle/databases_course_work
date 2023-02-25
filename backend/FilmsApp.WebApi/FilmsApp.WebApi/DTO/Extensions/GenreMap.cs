using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class GenreMap
	{
		public static GenreDTO ToDTO(this Genre genre)
		{
			return new GenreDTO
			{
				Id = genre.Id,
				Name = genre.Name
			};
		}
	}
}
