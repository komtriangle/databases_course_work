using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.WebApi.Controllers
{
	[Route("[controller]")]
	[Authorize]
	public class CommentsController: Controller
	{
		private readonly ICommentsService _commentsService;
		private readonly ILogger<CommentsController> _logger;

		public CommentsController(
			ICommentsService commentsService,
			ILogger<CommentsController> logger)
		{
			_commentsService = commentsService ??
				throw new ArgumentNullException(nameof(commentsService));

			_logger = logger
				?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment([FromBody] CommentDTO commentDTO)
		{
			try
			{
				int commentId = await _commentsService.CreateAsync(commentDTO);
				return Ok(commentDTO);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время сохранения комментария");
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteComment(int commentId)
		{
			try
			{
				await _commentsService.DeleteAsync(commentId);
				return Ok();
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время удаления комментария");
				return BadRequest(ex.Message);
			}
		}
	}
}
