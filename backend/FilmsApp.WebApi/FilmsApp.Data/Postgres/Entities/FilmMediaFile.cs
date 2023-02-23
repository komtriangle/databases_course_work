namespace FilmsApp.Data.Entities
{
	public class FilmMediaFile
	{
		public int Id { get; set; }
		public int MediaFileId { get; set; }
		public int FileId { get; set; }

		public virtual Film Film { get; set; }
		public virtual MediaFile MediaFile { get; set; }
	}
}
