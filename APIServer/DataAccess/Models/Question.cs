using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
	public class Question
	{
		public int Answers;
		public string Author;
		public string Content;
		public string Id;
		public List<Tag> Tags;
		public DateTime Time;
		public string Title;
		public int Views;
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