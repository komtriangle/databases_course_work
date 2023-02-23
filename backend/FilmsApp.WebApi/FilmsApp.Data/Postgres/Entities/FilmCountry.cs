namespace FilmsApp.Data.Entities
{
	public class FilmCountry
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public int CountryId { get; set; }
		public virtual Film Film { get; set; }
		public virtual Country Country { get; set; }
	}
}
