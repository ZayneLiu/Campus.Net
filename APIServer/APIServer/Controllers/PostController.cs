using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.Threading;

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // GET api/post
        [HttpGet]
        public ActionResult<object> Method()
        {
            return new DataAcess.Models.Question { ID = "adf", Time = DateTime.Now };
        }

        [HttpGet("{id}")]
        public ActionResult<object> GetPostById(int id)
        {
            return new Dictionary<string, object> { { "name", "asdf" }, { "time", DateTime.Now } };
        }

    }
}
