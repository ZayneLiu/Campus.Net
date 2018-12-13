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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace APIServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserService _userService;

		public UsersController(UserService userService) => _userService = userService;

		#region Login & Register

		// 登陆
		// POST: api/users/login
		[HttpPost("login")]
		[Produces("application/json")]
		public ActionResult<User> Login([FromBody] JObject userToLogin)
		{
			var userIn = JsonConvert.DeserializeObject<User>(userToLogin.ToString());
			var userResult = userIn.Email == null
				? _userService.GetUserByScid(userIn.SCID)
				: _userService.GetUserByEmail(userIn.Email);
			// return userResult == null ? (ActionResult<User>)NotFound():userResult; 
			return userResult ?? (ActionResult<User>)NotFound();
		}

		// 注册
		// POST: api/users/register
		[HttpPost("register")]
		[Produces("application/json")]
		public ActionResult<User> Register([FromBody] JObject userToRegister)
		{
			// 判断该学号是否已注册，如果未注册，则注册用户，并返回创建结果；已注册返回 false
			var userIn = JsonConvert.DeserializeObject<User>(userToRegister.ToString());
			// 调用注册方法 并返回注册结果
			if (_userService.GetUserByScid(userIn.SCID) == null) return NoContent();
			// 调用注册方法 并返回注册结果
			var userCreated = _userService.Create(userIn);
			return userCreated;
		}

		#endregion

		// 获取所有用户
		// GET: api/users/
		[HttpGet("all")]
		[Produces("application/json")]
		public ActionResult<List<User>> GetAllUsers()
		{
			return _userService.GetAllUsers();
		}

		/* 	根据提供内容 获取对应用户
		 * 	{ "scid": "201719192308" }
		 * 	{ "username": "zayne" }
		 * 	{ "email": "llz981011@hotmail.com" }
		**/
		// GET: api/users/
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<User> GetUserByInfo([FromBody] JObject keyValuePair)
		{
			Console.WriteLine(keyValuePair);
			var list = new List<string> { "scid", "username", "email", "id" };
			var info = keyValuePair.ToObject<Dictionary<string, string>>();
			var a = info.Keys.ToList().Select(key => list.Contains(key) ? key : null).First();
			switch (a)
			{
				case "scid": return _userService.GetUserByScid(info[a]);
				case "username": throw new NotImplementedException();
				case "email": return _userService.GetUserByEmail(info[a]);
			}
			return null;
		}

		// 获得对应 Id 的用户
		// GET: api/users/{string: id}
		[HttpGet("{id}")]
		[Produces("application/json")]
		public ActionResult<User> GetUserById(string id)
		{
			var userOut = _userService.GetUserById(new ObjectId(id));
			return userOut;
		}

		// 更新对应 Id 的用户
		// PUT: api/values/{string: id}
		[HttpPut("{id}")]
		[Produces("application/json")]
		public ActionResult<User> UpdateUserById(string id, [FromBody] JObject jUser)
		{
			var userIn = jUser.ToObject<User>();
			var userOut = _userService.Update(new ObjectId(id), userIn);
			return userOut;
		}

		// 删除对应 Id 的用户
		// DELETE: api/values/{string: id}
		[HttpDelete("{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public ActionResult DeleteUserById(string id)
		{
			var deleteResult = _userService.Delete(new ObjectId(id));
			return NoContent();
		}
	}
}