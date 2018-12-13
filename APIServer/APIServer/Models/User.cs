#region

using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

#endregion

namespace APIServer.Models
{
	/// <summary>
	///     User.
	/// </summary>
	public class User
	{
		[BsonId] public ObjectId Id;
		[BsonElement] public string Username;
		[BsonElement] public string SCID;
		[BsonElement] public string Password;
		[BsonElement] public string Email;
		[BsonIgnore] public string Tel;
		[BsonIgnore] public string RealName;
		[BsonIgnore] public string Gender;
		[BsonIgnore] public DateTime Birthday;
		[BsonIgnore] public string Biography;
		[BsonIgnore] public List<string> MyInvolvement;
		[BsonIgnore] public List<string> MyStars;
		[BsonIgnore] public List<string> MyWatchlist;
	}
}