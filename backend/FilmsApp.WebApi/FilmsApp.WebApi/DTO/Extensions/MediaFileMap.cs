using FilmsApp.Data.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class MediaFileMap
	{
		public static MediaFileDTO ToDTO(this FilmMediaFile filmMediaFile)
		{
			return new MediaFileDTO
			{
				Id = filmMediaFile.Id,
				MediaFileExtension = filmMediaFile.MediaFile.MediaFileExtension.ToDTO(),
				Path = filmMediaFile.MediaFile.Path,
				Type = filmMediaFile.Type
			};
		}

		public static MediaFileDTO ToDTO(this PersonMediaFile filmMediaFile)
		{
			return new MediaFileDTO
			{
				Id = filmMediaFile.Id,
				MediaFileExtension = filmMediaFile.MediaFile.MediaFileExtension.ToDTO(),
				Path = filmMediaFile.MediaFile.Path,
				Type = 0
			};
		}
	}
}
