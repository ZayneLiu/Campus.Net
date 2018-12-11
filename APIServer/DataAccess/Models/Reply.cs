﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
	public class Reply
	{
		public string Id;
		public DateTime Time;
		public string Author;
		public string Content;
		public int Likes;
		public List<Reply> Replies;
	}
}