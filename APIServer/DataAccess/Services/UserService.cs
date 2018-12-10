using System.Collections.Generic;
using System.Net.Sockets;
using System;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.Services
{
	public class UserService
	{
		private readonly IMongoCollection<User> _users;

		public UserService(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetConnectionString("Campus_Net"));
			var db = client.GetDatabase("campus_net");
			_users = db.GetCollection<User>("users");
		}
		
		// 创建新的用户 并返回已创建成功的 User 对象
		public User Create(User userIn)
		{
			_users.InsertOne(userIn);
			return userIn;
		}

		#region Read
		// 获取所有用户
		public List<User> GetAllUsers()
		{
			return _users.Find(user => true).ToList();
		}

		// 通过学号查找用户 并返回 User 对象
		public User GetUserByScid(string scid)
		{
			return _users.Find(user => user.SCID == scid).FirstOrDefault();
		}

		// 通过 Email 查找用户 并返回 User 对象
		public User GetUserByEmail(string email)
		{
			return _users.Find(user => user.Email == email).FirstOrDefault();
		}

		// 通过 UserId 查找用户 并返回 User 对象
		public User GetUserById(ObjectId id)
		{
			return _users.Find(user => user.Id == id).FirstOrDefault();
		}

		// 查找用户 (Base)
		public User GetUser(IFindFluent<User, User> findResult)
		{
			#region snippets
			////var result = Mongo.Query(dict);
			////#region 处理查询结果中的 _id 字段
			////var id = result.GetElement("_id").Value.AsObjectId.ToString();
			////result.Remove("_id");
			////result.AddRange(new Dictionary<string, string> { { "id", id } });
			////#endregion
			////return JObject.Parse(result.ToJson()).ToObject<User>();

			////var filter = dict.ContainsKey("_id")
			////? Builders<User>.Filter.Eq(user => user.Id, new ObjectId(dict["_id"]))
			////: Builders<User>.Filter.Eq(dict.Keys.First(), dict.Values.First());
			//#region Projection
			//// 排除 _id
			//// var projection = Builders<BsonDocument>.Projection.Exclude("_id");
			//// 返回查询结果的 第一个 如果没有匹配记录则返回 null
			//// var result = Users.Find(filter).Project(projection).FirstOrDefault();
			//#endregion
			//var result = find.FirstOrDefault();

			//// 判断查询结果是否为空，并返回映射后的 User 对象
			//// user = result == null ? null : result;
			//// ==coalesce Start==
			//return result ?? null;
			#endregion
			return findResult.FirstOrDefault();
		}
		#endregion

		public User Update(ObjectId id, User editedUser)
		{
			return _users.ReplaceOne(user => user.Id == id, editedUser).IsAcknowledged? editedUser: null;
		}

		public long Delete(ObjectId id)
		{
			var deleteResult =  _users.DeleteOne(user => user.Id == id);
			Console.WriteLine($"{deleteResult.DeletedCount} question modified");
			return deleteResult.DeletedCount;
		}
	}
}