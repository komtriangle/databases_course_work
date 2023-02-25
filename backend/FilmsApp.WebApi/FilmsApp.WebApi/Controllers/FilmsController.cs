﻿using FilmsApp.Data;
using FilmsApp.Data.Mapper;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmsController : Controller
	{

		private readonly IFilmService _filmService;
		private readonly IMongoRepositiory mongoRepositiory;
		private readonly IDbContextFactory<FilmsContext> dbContextFactory;
		public FilmsController(IFilmService filmService, IMongoRepositiory mongoRepositiory, IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_filmService = filmService ??
				throw new ArgumentNullException(nameof(filmService));

			this.mongoRepositiory = mongoRepositiory;
			this.dbContextFactory = dbContextFactory;
		}

		[HttpGet("SearchFilms")]
		public async Task<IActionResult> SearchFilms(string? searchQuery = null, int count = 20, int offset =0)
		{
			return Json(await _filmService.SearchFilms(searchQuery, count, offset));
		}

		[HttpGet("GetById{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status200OK)]

		public async Task<IActionResult> GetFilm(int id)
		{
			try
			{
				FilmDTO film = await _filmService.GetFilmAsync(id);

				if(film == null)
				{
					return NotFound($"Фильм с Id: {id} не найден");
				}

				return Json(film);
			}
			catch(Exception ex)
			{
				return BadRequest("Ошибка во время поиска фильма");
			}
			
		}


		[HttpGet("FillMongo")]
		public async Task<IActionResult> FillMongo()
		{
			using(FilmsContext context = dbContextFactory.CreateDbContext())
			{
				var films = context.Films.ToArray().Select(x => x.ToMongoModel());

				foreach(var film in films)
				{
					await mongoRepositiory.CreateFilmAsync(film);
					Console.WriteLine(film.Name);
				}
			}

			return Json(1);
			
		}
	}
}