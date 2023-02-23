namespace FilmsApp.Data.Entities
{
	public class PersonMediaFile
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public int MediaaFileId { get; set; }

		public virtual Person Person { get; set; }
		public virtual MediaFile MediaFile { get; set; }
	}
}
