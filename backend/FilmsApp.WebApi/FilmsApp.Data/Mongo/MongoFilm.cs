using MongoDB.Bson.Serialization.Attributes;

namespace FilmsApp.Data.Mongo
{
	public class MongoFilm
	{
		[BsonId]
		public int Id { get; set; }
		public string Name { get; set; }
		public string EngName { get; set; }
		public string Description { get; set; }
		public int YearOfRelease { get; set; }
		public double Rating { get; set; }
		public int Length { get; set; }
		public int FilmTypeId { get; set; }
		public string FilmType { get; set; }

		public MongoFilmPerson[] Persons { get; set; }

		public string[] Genres { get; set; }

		public string[] Countries { get; set; }

	}
}
