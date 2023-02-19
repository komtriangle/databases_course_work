namespace FilmsApp.Data.Entities
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<FilmGenre> Films { get; set; }

		public Genre()
		{
			Films = new HashSet<FilmGenre>();
		}
	}
}
