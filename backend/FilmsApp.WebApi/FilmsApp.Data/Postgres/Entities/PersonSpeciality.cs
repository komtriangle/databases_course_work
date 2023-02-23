namespace FilmsApp.Data.Entities
{
	public class PersonSpeciality
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public int SpecialityId { get; set; }
		public virtual Person Person { get; set; }
		public virtual Speciality Speciality { get; set; }
	}
}
