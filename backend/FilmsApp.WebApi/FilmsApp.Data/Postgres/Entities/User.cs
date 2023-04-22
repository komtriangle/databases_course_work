namespace FilmsApp.Data.Postgres.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }

		public virtual ICollection<UserRoles> Roles { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }

		public User()
		{
			Roles = new HashSet<UserRoles>();
			Comments = new HashSet<Comment>();
		}

	}
}
