using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class GenderMap
	{
		public static GenderDTO ToDTO(this Gender gender)
		{
			return new GenderDTO
			{
				Id = gender.Id,
				Value = gender.Value
			};
		}
	}
}
