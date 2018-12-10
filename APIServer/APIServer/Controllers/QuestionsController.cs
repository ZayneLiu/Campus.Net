using System;
using System.Collections.Generic;
using System.Linq;
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

		// GET: api/questions
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<List<Question>> GetAllQuestions()
		{
			return  _questionService.GetAllQuestions();
		}

		// GET: api/questions/{string: id}
		[HttpGet("{id}")]
		[Produces("application/json")]
		public ActionResult<Question> GetQuestionById(string id)
		{
			return _questionService.GetQuestionById(new ObjectId(id));
		}
		// POST: api/questions
		[HttpPost]
		[Produces("application/json")]
		public ActionResult<Question> CreateQuestion([FromBody]JObject jObject)
		{
			var question = jObject.ToObject<Question>();
			var questionCreated = _questionService.Create(question);
			return  questionCreated;
		}
		
		// PUT: api/questions/{string: id}
		[HttpPut("{id}")]
		[Produces("application/json")]
		public ActionResult<Question> UpdateQuestion(string id, [FromBody]JObject question)
		{
			var questionIn = question.ToObject<Question>();
			var questionOut = _questionService.Update(new ObjectId(id), questionIn);
			return questionOut;
		}
		
		// DELETE: api/questions/{string: id}
		[HttpDelete("{id}")]
		[Produces("application/json")]
		public ActionResult DeleteQuestion(string id)
		{
			var deleteResult = _questionService.Delete(new ObjectId(id));
			return NoContent();
		}
	}
}