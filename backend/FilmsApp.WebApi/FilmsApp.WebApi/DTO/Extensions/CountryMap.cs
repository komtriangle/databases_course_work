using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class CountryMap
	{
		public static CountryDTO ToDTO(this Data.Entities.Country country)
		{
			return new CountryDTO
			{
				Id = country.Id,
				Name = country.Name
			};
		}
	}
}
