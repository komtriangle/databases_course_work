namespace FilmsApp.Data.Entities
{
	public class Speciality
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<PersonSpeciality> People { get; set; }
		public virtual ICollection<FilmPerson> FilmPeople { get; set; }

		public Speciality()
		{
			People = new HashSet<PersonSpeciality>();
			FilmPeople = new HashSet<FilmPerson>();
		}
	}
}
