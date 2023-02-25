using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class MediaFileExtensionMap
	{
		public static MediaFileExtensionDTO ToDTO(this MediaFileExtension mediaFile)
		{
			return new MediaFileExtensionDTO
			{
				Id = mediaFile.Id,
				Extension = mediaFile.Extension,
			};
		}
	}
}
