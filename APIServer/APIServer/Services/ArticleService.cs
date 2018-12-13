using System;
using System.Collections.Generic;
using APIServer.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace APIServer.Services
{
	public class ArticleService
	{
		private readonly IMongoCollection<Article> _articles;

		public ArticleService(IConfiguration configuration)
		{
			var client = new MongoClient(configuration.GetConnectionString("Campus_Net"));
			var db = client.GetDatabase("campus_net");
			_articles = db.GetCollection<Article>("articles");
		}

		#region Create

		public Article Create(Article articleIn)
		{
			_articles.InsertOne(articleIn);
			return articleIn;
		}
		#endregion

		#region Read

		public List<Article> GetAllArticles()
		{
			var articles = _articles.Find(a => true).ToList();
			return articles;
		}

		public Article GetArticleById(ObjectId id)
		{
			var article = _articles.Find(a => a.Id == id).FirstOrDefault();
			return article;
		}
		#endregion

		#region Update

		public Article Update(ObjectId id, Article articleIn)
		{
			var replaceOneResult = _articles.ReplaceOne(a => a.Id == id, articleIn);
			Console.WriteLine($"{replaceOneResult.ModifiedCount} question modified");
			return articleIn;
		}

		#endregion

		public long Delete(ObjectId id)
		{
			var deleteResult = _articles.DeleteOne(a => a.Id == id);
			Console.WriteLine($"{deleteResult.DeletedCount} question modified");
			return deleteResult.DeletedCount;
		}

	}
}
