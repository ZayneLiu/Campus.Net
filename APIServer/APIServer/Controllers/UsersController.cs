using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DataAccess.Services;
using System.Collections.Generic;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using DataAccess.Models;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace APIServer.Controllers
{
	//[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserService _userService;

		public UsersController(UserService userService)
		{
			_userService = userService;
		}
		// GET: api/users/
		/* 	获取所有用户
		**/
		[HttpGet]
		public ActionResult<List<User>> GetAllUsers()
		{
			return _userService.GetAllUsers();
		}

		// POST api/users/			
		/* 	根据提供内容 获取对应用户
		 * 	 
		 * 	{ "scid": "201719192308" }
		 * 	{ "username": "zayne" }
		 * 	{ "email": "llz981011@hotmail.com" }
		 * 	{ "id": "5bfa7b9f9082b5481ab119cd" }
		**/
		[HttpPost]
		public ActionResult<User> Get([FromBody] JObject post)
		{


			Console.WriteLine(post);
			var list = new List<string> { "scid", "username", "email", "id" };
			var info = post.ToObject<Dictionary<string, string>>();
			var a = info.Keys.ToList<string>().Select<string, string>(key => list.Contains(key) ? key : null).First();
			switch (a)
			{
				case "scid":
					return _userService.GetUserBySCID(info[a]);
				case "username":
					throw new NotImplementedException();
				case "email":
					return _userService.GetUserByEmail(info[a]);

				case "id":
					return _userService.GetUserById(new ObjectId(info[a]));
			}
			return null;
			//return _userService.GetUserBySCID(post);
		}

		// POST api/users/login
		[HttpPost("/api/users/login")]
		public ActionResult<User> Login([FromBody] JObject post)
		{
			var loginResult = false;
			var userIn = JsonConvert.DeserializeObject<User>(post.ToString());
			var userResult = userIn.Email == null
			? _userService.GetUserBySCID(userIn.SCID)
			: _userService.GetUserByEmail(userIn.Email);
			if (userResult == null)
			{
				return NotFound();
			}

			loginResult = userIn.Password == userResult.Password;
			var postResult = new JObject
			{
				{ "success", loginResult },
				{ "userId", userResult.Id.ToString() }
			};
			//return postResult;
			return userResult;
		}


		[HttpPost("/api/users/register")]
		public ActionResult<User> Register([FromBody] JObject post)
		{
			// 判断该学号是否已注册，如果未注册，则注册用户，并返回创建结果；已注册返回 false

			var userIn = JsonConvert.DeserializeObject<User>(post.ToString());
			var resultUser = new User();
			// 调用注册方法 并返回注册结果
			var isExisted = _userService.GetUserBySCID(userIn.SCID) == null;
			if (isExisted)
			{
				return null;
			}
			// 调用注册方法 并返回注册结果
			var userCreated = _userService.Create(userIn);
			if (userCreated == null)
			{
				return userCreated;
			}
			return null;
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}