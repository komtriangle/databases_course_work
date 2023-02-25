namespace FilmsApp.WebApi.DTO
{
	public class FilmDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string EngName { get; set; }
		public string Description { get; set; }
		public int YearOfRelease { get; set; }
		public double Rating { get; set; }
		public int Length { get; set; }

		public  FilmTypeDTO FilmType { get; set; }
		public CountryDTO[] Countries { get; set; }
		public MediaFileDTO[] MediaFiles { get; set; }
		public GenreDTO[] Genres { get; set; }
		public FilmPersonDTO[] FilmPeople { get; set; }
	}
}
