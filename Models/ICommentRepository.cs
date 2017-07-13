using System.Collections.Generic;

namespace Cahaya.Models
{
	public interface ICommentRepository
	{
		IEnumerable<Comments> GetAllComments();
	}
}