using System;

namespace FilmsApp.Data.Entities
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Growth { get; set; }
		public DateTime DateBirth { get; set; }
		public DateTime DateDeath { get; set; }
		public string BirthPlace { get; set;}
		public int GenderId { get; set; }
		public virtual Gender Gender { get; set; }

		public virtual ICollection<PersonSpeciality> Specialities { get; set; }
		public virtual ICollection<PersonMediaFile> MediaFiles { get; set; }
		public virtual ICollection<FilmPerson> Films { get; set; }

		public Person()
		{
			Specialities = new HashSet<PersonSpeciality>();
			MediaFiles = new HashSet<PersonMediaFile>();
			Films = new HashSet<FilmPerson>();
		}
	}
}
