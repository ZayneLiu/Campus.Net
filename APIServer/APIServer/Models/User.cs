#region

using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Serializers;

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
		[BsonElement] public string Tel;
		[BsonElement] public string RealName;
		[BsonElement] public string Gender;
		[BsonElement]
		public DateTime Birthday;
		[BsonElement] public string Biography;
	}
}