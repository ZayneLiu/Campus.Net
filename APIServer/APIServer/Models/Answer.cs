using System;
using System.Collections.Generic;

namespace APIServer.Models
{
	public class Answer
	{
		public DateTime Time;
		public string Author;
		public string Content;
		public int Approvals;
		public List<Reply> Replies;
	}
}