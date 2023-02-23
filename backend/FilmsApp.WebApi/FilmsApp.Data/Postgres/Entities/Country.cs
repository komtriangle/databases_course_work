namespace FilmsApp.Data.Entities
{
	public class Country
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<FilmCountry> Countries { get; set; }

		public Country()
		{
			Countries = new HashSet<FilmCountry>();
		}
	}
}
