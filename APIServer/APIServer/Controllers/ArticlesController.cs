using System;
using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace APIServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly ArticleService _articleService;

		public ArticlesController(ArticleService articleServiceService)
		{
			_articleService = articleServiceService;
		}

		// GET api/articles
		[HttpGet]
		public ActionResult<List<Article>> GetAllArticles()
		{
			return  _articleService.GetAllArticles();
		}

		// GET api/articles/5
		[HttpGet("{id}")]
		public ActionResult<Article> GetArticleById(string id)
		{
			return _articleService.GetArticleById(new ObjectId(id));
		}

		// POST api/articles
		[HttpPost]
		public ActionResult<Article> CreateArticle([FromBody] JObject jArticle)
		{
			var article = jArticle.ToObject<Article>();
			_articleService.Create(article);
			return article;
		}

		// PUT api/articles/5
		[HttpPut("{id}")]
		public ActionResult<Article> UpdateArticle(string id, [FromBody] JObject jArticle)
		{
			var articleIn = _articleService.GetArticleById(new ObjectId(id));
			var articleEdited = _articleService.Update(new ObjectId(id), articleIn);
			return articleEdited;
		}

		// DELETE api/articles/5
		[HttpDelete("{id}")]
		public ActionResult DeleteArticle(string id)
		{
			var deleteResult = _articleService.Delete(new ObjectId(id));
			return NoContent();
		}
	}
}