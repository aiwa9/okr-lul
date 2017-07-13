using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cahaya.Models
{
	public class CommentRepository : ICommentRepository
	{
		private CommentContext _context;
		private ILogger<CommentRepository> _logger;

		public CommentRepository(CommentContext context, ILogger<CommentRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IEnumerable<Comments> GetAllComments()
		{
			_logger.LogInformation("Getting All Comments from the database");
			return _context.Comments.ToList();
		}
	}
}
