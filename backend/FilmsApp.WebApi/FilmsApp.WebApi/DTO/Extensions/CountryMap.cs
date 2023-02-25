using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class CountryMap
	{
		public static CountryDTO ToDTO(this Country country)
		{
			return new CountryDTO
			{
				Id = country.Id,
				Name = country.Name
			};
		}
	}
}
