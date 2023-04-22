using FilmsApp.Data.Postgres.Entities;

namespace FilmsApp.WebApi.DTO.Extensions
{
	public static class CommentMap
	{
		public static CommentDTO ToDTO(this Comment comment)
		{
			return new CommentDTO
			{
				Id = comment.Id,
				UserId = comment.UserId,
				FilmId = comment.UserId,
				Stars = comment.Stars,
				Text = comment.Text,
			};
		}
	}
}
