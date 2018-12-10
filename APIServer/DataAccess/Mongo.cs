using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using DataAccess.Models;

namespace DataAccess
{
	public class Mongo
	{
		private static MongoClient Client => new MongoClient("mongodb://192.168.99.100:32768");
		private static IMongoDatabase CampusNet => Client.GetDatabase("campus_net");
		static public IMongoCollection<BsonDocument> Posts => CampusNet.GetCollection<BsonDocument>("posts");
		static public IMongoCollection<BsonDocument> Questions => CampusNet.GetCollection<BsonDocument>("questions");
		//static public IMongoCollection<BsonDocument> Users => CampusNet.GetCollection<BsonDocument>("users");
		static public IMongoCollection<User> Users => CampusNet.GetCollection<User>("users");

		static public User Query(Dictionary<string, string> dict)
		{
			// 定义查询条件
			//var filter = dict.ContainsKey("_id")
			//? Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(dict["_id"]))
			//: Builders<BsonDocument>.Filter.Eq(dict.Keys.First(), dict.Values.First());

			var filter = dict.ContainsKey("_id")
			//? Builders<User>.Filter.Eq("_id", new ObjectId(dict["_id"]))
			? Builders<User>.Filter.Eq(user => user.Id, new ObjectId(dict["_id"]))
			: Builders<User>.Filter.Eq(dict.Keys.First(), dict.Values.First());
			#region Projection
			// 排除 _id
			// var projection = Builders<BsonDocument>.Projection.Exclude("_id");
			// 返回查询结果的 第一个 如果没有匹配记录则返回 null
			// var result = Users.Find(filter).Project(projection).FirstOrDefault();
			#endregion
			// 带 _id 字段查询出来
			var result = Users.Find<User>(filter).FirstOrDefault();
			//var result = Users.Find(filter).FirstOrDefault();

			// 判断查询结果是否为空，并返回映射后的 User 对象
			// user = result == null ? null : result;
			/* coalesce 表达式 ==Start==*/
			return result ?? null;
		}
	}
}