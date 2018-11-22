using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess
{
	public class Mongo
	{
		private static MongoClient Client => new MongoClient("192.168.99.100:32768");
		private static IMongoDatabase CampusNet => Client.GetDatabase("campus_net");
		public IMongoCollection<BsonDocument> Posts => CampusNet.GetCollection<BsonDocument>("posts");
		public IMongoCollection<BsonDocument> Questions => CampusNet.GetCollection<BsonDocument>("questions");
		public IMongoCollection<BsonDocument> Users => CampusNet.GetCollection<BsonDocument>("users");
	}
}