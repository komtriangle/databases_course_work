using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FilmsApp.WebApi.DTO
{
	public class CommentDTO
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int FilmId { get; set; }
		public string Text { get; set; }
		public short Stars { get; set; }
	}
}
