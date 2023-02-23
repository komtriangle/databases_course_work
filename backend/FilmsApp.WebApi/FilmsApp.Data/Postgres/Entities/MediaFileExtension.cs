namespace FilmsApp.Data.Entities
{
	public class MediaFileExtension
	{
		public int Id { get; set; }
		public string Extension { get; set; }

		public int MediaFileTypeId { get; set; }
		public virtual MediaFileType MediaFileType { get; set; }

		public virtual ICollection<MediaFile> MediaFiles { get; set; }

		public MediaFileExtension()
		{
			MediaFiles = new HashSet<MediaFile>();
		}
	}
}