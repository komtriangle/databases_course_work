using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class SpecialityMap
	{
		public static SpecialityDTO ToDTO(this Speciality speciality)
		{
			return new SpecialityDTO
			{
				Id = speciality.Id,
				Name = speciality.Name
			};
		}
	}
}
