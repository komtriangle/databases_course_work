namespace FilmsApp.Data.Entities
{
	public class FilmGenre
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public int GenreId { get; set; }
		public virtual Film Film { get; set; }
		public virtual Genre Genre { get; set; }
	}
}
