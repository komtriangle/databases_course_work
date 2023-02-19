namespace FilmsApp.Data.Entities
{
	public class Gender
	{
		public int Id { get; set; }
		public string Value { get; set; }
		public ICollection<Person> People { get; set;}

		public Gender()
		{
			People = new HashSet<Person>();
		}
	}
}
