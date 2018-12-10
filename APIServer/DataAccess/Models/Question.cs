using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
	public class Question
	{
		[BsonId]
		public ObjectId Id;
		[BsonElement]
		public string Title;
		[BsonElement]
		public List<Tag> Tags;
		[BsonElement]
		public string AuthorId;
		[BsonElement]
		public DateTime Time;
		[BsonElement]
		public string Content;
		[BsonElement]
		public List<Answer> Answers;
		[BsonElement]
		public int Views;
		[BsonElement]
		public int Votes;
	}

	public class Answer
	{
		public int Approvals;
		public string Author;
		public string Content;
		public string Id;
		public List<Reply> Replies;
		public DateTime Time;
	}

	public class Tag
	{
		public string Description;
		public string Id;
		public string Name;
	}

	public class Reply
	{
		public string Author;
		public string Content;
		public string Id;
		public int Likes;
		public List<Reply> Replies;
		public DateTime Time;
	}
}