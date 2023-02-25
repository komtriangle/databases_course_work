using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class PersonMap
	{
		public static PersonDTO ToDTO(this Person person)
		{

			return new PersonDTO
			{
				Id = person.Id,
				Name = person.Name,
				Growth = person.Growth,
				DateBirth = person.DateBirth,
				DateDeath = person.DateDeath,
				BirthPlace = person.BirthPlace,
				Gender = person.Gender?.ToDTO(),
				Specialities = person?.Specialities?
					.Select(x => x.Speciality?.ToDTO())
					.Where(x => x != null)
					.ToArray(),
				MediaFiles = person?.MediaFiles?
					.Select(x => x.MediaFile?.ToDTO())
					.Where(x => x != null)
					.ToArray(),
				Films = person?.Films?
					.Select(x => x.Film?.ToDTO())
					.Where(x => x != null)
					.ToArray()
			};
		}
	}
}
