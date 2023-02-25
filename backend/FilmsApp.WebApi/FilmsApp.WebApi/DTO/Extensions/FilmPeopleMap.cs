using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class FilmPeopleMap
	{
		public static FilmPersonDTO ToDTO(this FilmPerson filmPerson)
		{
			var filmPersonTmp = new Person
			{
				Id = filmPerson.Person.Id,
				BirthPlace = filmPerson.Person.BirthPlace,
				DateDeath = filmPerson.Person.DateDeath,
				Name = filmPerson.Person.Name,
				DateBirth = filmPerson.Person.DateBirth,
				Films = Array.Empty<FilmPerson>(),
				Gender = filmPerson.Person.Gender,
				Growth = filmPerson.Person.Growth,
				MediaFiles = filmPerson.Person.MediaFiles,
				Specialities = filmPerson.Person.Specialities
			}
			;
			return new FilmPersonDTO
			{
				Person = filmPersonTmp?.ToDTO(),
				Speciality = filmPerson.Speciality.ToDTO()
			};
		}
	}
}
