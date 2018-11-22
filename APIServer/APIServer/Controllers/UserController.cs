using System;
using System.Text.RegularExpressions;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//using MongoDB.Bson.IO;

namespace APIServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		// GET: api/user/
		[HttpGet]
		public ActionResult<JObject> Get()
		{
			Console.WriteLine();
			return JObject.Parse("{}");
		}

		// GET api/user/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return string.Format("id 为 {0} 的用户", id);
		}

		// POST api/user
		[HttpPost]
		public ActionResult<string> Post([FromBody] JObject form)
		{
			// var login = form["login"].Value<string>();
			// var password = form["password"].Value<string>();
			// +++++前端已做数据校验，并重构登陆对象+++++
			// var type = "email";

			// try
			// {
			// 	// 判断是否为 Email
			// 	new MailAddress(login);
			// }
			// catch
			// {
			// 	// 判断是否为 纯数字
			// 	foreach (var item in login.ToCharArray())
			// 	{
			// 		var temp = 0;
			// 		if (!int.TryParse(item.ToString(), out temp))
			// 		{
			// 			return "FAILED";
			// 		}
			// 	}
			// 	type = "scid";
			// }

			// 构造完整登陆 用户对象
			var loginresult = form.ToObject<User>();

			// 返回登陆结果
			return "SUCCESS";
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