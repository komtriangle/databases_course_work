namespace FilmsApp.Data.Entities
{
	public class MediaFileType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<MediaFileExtension> MediaFileExtensions { get; set; }

		public MediaFileType()
		{
			MediaFileExtensions = new HashSet<MediaFileExtension>();
		}

	}
}
