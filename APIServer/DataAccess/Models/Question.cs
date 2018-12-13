using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
	public class Question
	{
		[BsonId] public ObjectId Id;
		[BsonElement] public string Title;
		[BsonElement] public List<Tag> Tags;
		[BsonElement] public string AuthorId;

//		[BsonElement] public DateTime Time;
		[BsonElement] public string Content;
		[BsonElement] public List<Answer> Answers;
		[BsonElement] public int Views;
		[BsonElement] public int Votes;
	}
}