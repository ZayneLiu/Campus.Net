using System;
using System.Collections.Generic;
using System.Linq;
using APIServer.Models;
using APIServer.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

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
		public ActionResult<Question> CreateQuestion([FromBody]JObject jQuestion)
		{
			
			var question = jQuestion.ToObject<Question>();
			var questionCreated = _questionService.Create(question);
			return  questionCreated;
		}
		
		// PUT: api/questions/{string: id}
		[HttpPut("{id}")]
		[Produces("application/json")]
		public ActionResult<Question> UpdateQuestion(string id, [FromBody]JObject jQuestion)
		{
			var questionIn = jQuestion.ToObject<Question>();
			var questionEdited = _questionService.Update(new ObjectId(id), questionIn);
			return questionEdited;
		}
		
		// DELETE: api/questions/{string: id}
		[HttpDelete("{id}")]
		[Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public ActionResult DeleteQuestion(string id)
		{
			var deleteResult = _questionService.Delete(new ObjectId(id));
			return NoContent();
		}
	}
}