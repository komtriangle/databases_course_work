using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class MediaFileMap
	{
		public static MediaFileDTO ToDTO(this MediaFile mediaFile)
		{
			return new MediaFileDTO
			{
				Id = mediaFile.Id,
				MediaFileExtension = mediaFile.MediaFileExtension.ToDTO(),
				Path = mediaFile.Path,
			};
		}
	}
}
