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

		public UsersController(UserService userService)
		{
			_userService = userService;
		}

		#region Login & Register

		// POST api/users/login
		/// <summary>
		/// 登陆
		/// </summary>
		/// <param name="userToLogin">包含登陆信息的 JSON 对象</param>
		/// <returns>登陆成功后的用户信息</returns>
		[HttpPost("/api/Users/Login")]
		[Produces("application/json")]
//		[ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
		public ActionResult<User> Login([FromBody] JObject userToLogin)
		{
			var userIn = JsonConvert.DeserializeObject<User>(userToLogin.ToString());
			var userResult = userIn.Email == null
				? _userService.GetUserByScid(userIn.SCID)
				: _userService.GetUserByEmail(userIn.Email);
			// return userResult == null ? (ActionResult<User>)NotFound():userResult; 
			return userResult ?? (ActionResult<User>) NotFound();

			//			var loginResult = userIn.Password == userResult.Password;
			//			var postResult = new JObject
			//			{
			//				{ "success", loginResult },
			//				{ "userId", userResult.Id.ToString() }
			//			};
			//			return postResult;
		}

		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="userToRegister">包含注册信息的 JSON 对象</param>
		/// <returns>注册成功后的用户信息</returns>
		[HttpPost("/api/Users/Register")]
		[Produces("application/json")]
		public ActionResult<User> Register([FromBody] JObject userToRegister)
		{
			// 判断该学号是否已注册，如果未注册，则注册用户，并返回创建结果；已注册返回 false
			var userIn = JsonConvert.DeserializeObject<User>(userToRegister.ToString());
//			var resultUser = new User();
			// 调用注册方法 并返回注册结果
			if (_userService.GetUserByScid(userIn.SCID) == null)
				return NoContent();
			// 调用注册方法 并返回注册结果
			var userCreated = _userService.Create(userIn);
			return userCreated;
		}

		#endregion

		// GET: api/users/
		/* 	获取所有用户
		**/
		[HttpGet]
		[Produces("application/json")]
		public ActionResult<List<User>> GetAllUsers()
		{
			return _userService.GetAllUsers();
		}

		// POST api/users/
		/* 	根据提供内容 获取对应用户
		 * 	{ "scid": "201719192308" }
		 * 	{ "username": "zayne" }
		 * 	{ "email": "llz981011@hotmail.com" }
		 * 	{ "id": "5bfa7b9f9082b5481ab119cd" }
		**/
		[HttpPost]
		[Produces("application/json")]
		public ActionResult<User> Get([FromBody] JObject keyValuePair)
		{
			Console.WriteLine(keyValuePair);
			var list = new List<string> {"scid", "username", "email", "id"};
			var info = keyValuePair.ToObject<Dictionary<string, string>>();
			var a = info.Keys.ToList().Select(key => list.Contains(key) ? key : null).First();
			switch (a)
			{
				case "scid":
					return _userService.GetUserByScid(info[a]);
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


		// PUT api/values/5
		[HttpPut("{id}")]
		[Produces("application/json")]
		public ActionResult Put(string id, [FromBody] JObject jUser)
		{
			var userIn = jUser.ToObject<User>();
			var result = _userService.Update(new ObjectId(id), userIn);
			return result ? NoContent() : (ActionResult) NotFound();
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		[Produces("application/json")]
		public ActionResult Delete(string id)
		{
			var result = _userService.Delete(new ObjectId(id));
			return result ? NoContent() : (ActionResult) NotFound();
		}
	}
}