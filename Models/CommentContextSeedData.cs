using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cahaya.Models
{
    public class CommentContextSeedData
    {
		private CommentContext _context;

		public CommentContextSeedData(CommentContext context)
		{
			_context = context;
		}

		public async Task EnsureSeedData()
		{
			if (!_context.Comments.Any())
			{
				var usComment = new Comments()
				{
					//DateCreated = DateTime.UtcNow,
					Author = "Nizar",
					Id = 1,
					Text = "Test"
				};

				_context.Add(usComment);

				await _context.SaveChangesAsync();
			}

		}
    }
}
