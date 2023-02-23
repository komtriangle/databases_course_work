namespace FilmsApp.Data.Entities
{
	public class FilmPerson
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public int PersonId { get; set; }
		public int SpecialityId { get; set; }

		public virtual Film Film { get; set; }
		public virtual Person Person { get; set; }
		public virtual Speciality Speciality { get; set; }
	}
}
