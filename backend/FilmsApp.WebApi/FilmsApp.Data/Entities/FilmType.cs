namespace FilmsApp.Data.Entities
{
	public class FilmType
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Film> Films { get; set; }

		public FilmType()
		{
			Films = new HashSet<Film>();
		}
	}
}
