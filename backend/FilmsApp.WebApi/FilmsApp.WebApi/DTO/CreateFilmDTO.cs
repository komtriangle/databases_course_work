namespace FilmsApp.WebApi.DTO
{
	public class CreateFilmDTO
	{
		public string Name { get; set; }
		public string EngName { get; set; }
		public string Description { get; set; }
		public int YearOfRelease { get; set; }
		public int Length { get; set; }
		public int FilmTypeId { get; set; }
		public int[] CountriesIds { get; set; }
		public int[] GenresIds { get; set; }
		public CreateFilmPersonDTO[] PersonDTO { get; set; }

	}
}
