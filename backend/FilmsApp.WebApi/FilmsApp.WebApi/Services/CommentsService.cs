using FilmsApp.Data;
using FilmsApp.Data.Entities;
using FilmsApp.Data.Postgres.Entities;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class CommentsService : ICommentsService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public CommentsService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<int> CreateAsync(CommentDTO commentDto)
		{
			if (commentDto == null)
			{
				throw new Exception("Не передан объект комментария");
			}

			if (commentDto.Stars <= 0 || commentDto.Stars > 10)
			{
				throw new Exception("Количество звезд должно быть от 0 до 10");
			}


			using (FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
			{
				Film film = await context.Films.FindAsync(commentDto.FilmId);

				if (film == null)
				{
					throw new Exception($"Фильм с Id: {commentDto.FilmId} не найден");
				}

				Comment comment = new Comment
				{
					UserId = commentDto.UserId,
					Text = commentDto.Text,
					Stars = commentDto.Stars,
					FilmId = commentDto.FilmId
				};

				await context.Comments.AddAsync(comment);

				await context.SaveChangesAsync();

				return comment.Id;


			}
		}

		public async Task DeleteAsync(int id)
		{
			using (FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
			{
				Comment comment = await context.Comments.FindAsync(id);

				if(comment == null)
				{
					throw new Exception($"Комментарий с Id: {id} не найден");
				}

				context.Comments.Remove(comment);

				await context.SaveChangesAsync();
			}
		}
	}
}
