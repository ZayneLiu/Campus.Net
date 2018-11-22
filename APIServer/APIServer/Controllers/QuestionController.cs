using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace APIServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		// GET api/questions
		[HttpGet]
		public ActionResult<object> Method()
		{
			return new List<Question>
			{
				new Question
				{
					Id = "id_01",
					Votes = 21,
					Views = 12,
					Answers = 34,
					Title = "Title",
					Tags = new List<Tag>
					{
						new Tag
						{
							Id = "tag_id",
							Name = "tag_name",
							Description = "tag_desc"
						},
						new Tag
						{
							Id = "tag_id",
							Name = "tag_name",
							Description = "tag_desc"
						}
					}
				}
			};
		}

		// api/question
		[HttpGet("{id}")]
		public ActionResult<JObject> GetQuestionById(int id)
		{
			return JObject.Parse("{'name': 's', 'time': '" + DateTime.Now + "', 'id': '" + id + "'}");
		}
	}
}