using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cahaya.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cahaya.Controllers.Api
{
	[Route("api/comments")]
	public class CommentsController : Controller
	{
		ICommentRepository _repository;

		public CommentsController(ICommentRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("")]
		public IActionResult Get()
		{
			//if (true) return BadRequest("Bad things happened");
			//return Ok(new Comments() { Author = "Nizar", Id = 2, Text = "Holla Amigos" });
			return Ok(_repository.GetAllComments());
		}

		[HttpPost("")]
		public IActionResult Post([FromBody]Comments comments)
		{
			return Ok(true);
		}
	}
}
