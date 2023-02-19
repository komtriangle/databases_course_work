namespace FilmsApp.Data.Entities
{
	public class MediaFile
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public int MediaFileExtensionId { get; set; }
		public virtual MediaFileExtension MediaFileExtension { get; set; }

		public virtual ICollection<FilmMediaFile> Films { get; set; }
		public virtual ICollection<PersonMediaFile> People { get; set; }

		public MediaFile()
		{
			Films = new HashSet<FilmMediaFile>();
			People = new HashSet<PersonMediaFile>();
		}
	}
}
