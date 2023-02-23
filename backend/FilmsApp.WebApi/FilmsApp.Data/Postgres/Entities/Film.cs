namespace FilmsApp.Data.Entities
{
	public class Film
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string EngName { get; set; }
		public string Description { get; set; }
		public int YearOfRelease { get; set; }
		public float Rating { get; set; }
		/// <summary>
		/// Продолжительность фильма в минутах
		/// </summary>
		public int Length { get; set; }

		public int FilmTypeId { get; set; }

		public virtual FilmType FilmType { get; set; }

		/// <summary>
		/// Страны производства фильма
		/// </summary>
		public virtual ICollection<FilmCountry> Countries { get; set; }
		public virtual ICollection<FilmMediaFile> MediaFiles { get; set; }
		public virtual ICollection<FilmGenre> Genres { get; set; }
		public virtual ICollection<FilmPerson> People { get; set; }

		public Film()
		{
			Countries = new HashSet<FilmCountry>();
			MediaFiles = new HashSet<FilmMediaFile>();
			Genres = new HashSet<FilmGenre>();
			People = new HashSet<FilmPerson>();
		}


	}
}
