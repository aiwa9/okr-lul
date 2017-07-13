using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cahaya.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Cahaya.Controllers.Web
{
	public class HomeController : Controller
	{
		private static readonly IList<Comments> _comments;
		private IConfigurationRoot _config;
		private ICommentRepository _repository;
		private ILogger<HomeController> _logger;

		public HomeController(IConfigurationRoot config, ICommentRepository repository, ILogger<HomeController> logger)
		{
			_repository = repository;
			_config = config;
			_logger = logger;
		}

		static HomeController()
		{
			_comments = new List<Comments>
			{
				new Comments
				{
					Id = 1,
					Author = "Daniel Lo Nigro",
					Text = "Hello ReactJS.NET World!"
				},
				new Comments
				{
					Id = 2,
					Author = "Pete Hunt",
					Text = "This is one comment"
				},
				new Comments
				{
					Id = 3,
					Author = "Jordan Walke",
					Text = "This is *another* comment"
				},
			};
		}

		public IActionResult Index()
		{
			try
			{
				var data = _repository.GetAllComments();
				return View(data);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Failed to get trips in Index page: {ex.Message}");
				return Redirect("/error");
			}
		}

		public IActionResult Polo()
		{
			return View();
		}

		[Route("comments")]
		[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
		public ActionResult Comments()
		{
			return Json(_comments);
		}

		[Route("comments/new")]
		[HttpPost]
		public ActionResult AddComment(Comments comment)
		{
			// Create a fake ID for this comment
			comment.Id = _comments.Count + 1;
			_comments.Add(comment);
			return Content("Success :)");
		}
	}
}
