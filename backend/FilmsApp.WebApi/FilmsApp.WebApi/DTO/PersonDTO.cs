namespace FilmsApp.WebApi.DTO
{
	public class PersonDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Growth { get; set; }
		public DateTime? DateBirth { get; set; }
		public DateTime? DateDeath { get; set; }
		public string BirthPlace { get; set; }
		public int GenderId { get; set; }
		public GenderDTO Gender { get; set; }
		public SpecialityDTO[] Specialities { get; set; }
		public MediaFileDTO[] MediaFiles { get; set; }
		public FilmDTO[] Films { get; set; }
	}
}
