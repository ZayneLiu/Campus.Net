using MongoDB.Bson;

namespace APIServer.Models
{
	public class Author
	{
		public Author()
		{
		}

		public Author(ObjectId id) => _id = id;
		private ObjectId _id;
		public string Avatar;
	}
}