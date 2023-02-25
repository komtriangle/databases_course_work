using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class FilmTypeMap
	{
		public static FilmTypeDTO ToDTO(this FilmType filmType)
		{
			return new FilmTypeDTO
			{
				Id = filmType.Id,
				Name = filmType.Name
			};
		}
	}
}
