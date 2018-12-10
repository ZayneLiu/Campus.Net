using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.Services
{
	public class QuestionService
	{
		private readonly IMongoCollection<Question> _questions;

		public QuestionService(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetConnectionString("Campus_Net"));
			var db = client.GetDatabase("campus_net");
			_questions = db.GetCollection<Question>("questions");
		}

		#region Create

		public Question Create(Question questionIn)
		{
			_questions.InsertOne(questionIn);
			return questionIn;
		}
		#endregion

		#region Read

		public List<Question> GetAllQuestions()
		{
			var questions = _questions.Find(q => true).ToList();
			return questions;
		}

		public Question GetQuestionById(ObjectId id)
		{
			var question = _questions.Find(q => q.Id == id).FirstOrDefault();
			return question;
		}
		#endregion
		
		#region Update

		public Question Update(ObjectId id, Question questionIn)
		{
			var replaceOneResult = _questions.ReplaceOne(q => q.Id == id, questionIn);
			Console.WriteLine($"{replaceOneResult.ModifiedCount} question modified");
			return questionIn;
		}

		#endregion

		public long Delete(ObjectId id)
		{
			var deleteResult = _questions.DeleteOne(q => q.Id == id);
			Console.WriteLine($"{deleteResult.DeletedCount} question modified");
			return deleteResult.DeletedCount;
		}
	}
}