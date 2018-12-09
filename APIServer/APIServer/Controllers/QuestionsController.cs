using System;
using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace APIServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private readonly QuestionService _questionService;
		public QuestionsController(QuestionService questionService) => _questionService = questionService;

		// GET api/questions
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<List<Question>> Method()
		{
			return new List<Question>();
		}

//		// GET api/questions/{id}
//		[HttpGet("{id}")]
//		[Produces("application/json")]
//		public ActionResult<Question> GetQuestionById(string id)
//		{
//			return new Question
//			{
//				Id = id
//			};
//		}
		
		[HttpPost]
		[Produces("application/json")]
		public ActionResult<Question> CreateQuestion()
		{
			// create question
			return  new Question();
		}
		
		[HttpPut("{id}")]
		[Produces("application/json")]
		public ActionResult<Question> UpdateQuestion(string id, [FromBody]JObject question)
		{
			var questionIn = question.ToObject<Question>();
			var questionOut = _questionService.Update(new ObjectId(id), questionIn);
			return questionOut;
		}
		
		
	}
}