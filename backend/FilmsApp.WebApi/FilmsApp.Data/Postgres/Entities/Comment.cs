using FilmsApp.Data.Entities;

namespace FilmsApp.Data.Postgres.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public short Stars { get; set; }

		public int UserId { get; set; }
		public int FilmId { get; set; }
		public virtual User User { get; set; }
		public virtual Film Film { get; set; }

	}
}
