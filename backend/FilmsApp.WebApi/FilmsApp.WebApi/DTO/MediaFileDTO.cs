namespace FilmsApp.WebApi.DTO
{
	public class MediaFileDTO
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public  MediaFileExtensionDTO MediaFileExtension { get; set; }
	}
}
