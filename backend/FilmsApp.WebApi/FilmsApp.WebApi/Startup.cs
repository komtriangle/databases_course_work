using FilmsApp.Data;
using FilmsApp.Data.Configuration;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FilmsApp.WebApi
{
	public class Startup
	{
		private readonly IConfiguration _configuration;
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			services.AddSwaggerGen();

			var postgresConfig = _configuration.GetSection(nameof(PostgresConfig));

			services.Configure<PostgresConfig>(postgresConfig);

			services.AddDbContextFactory<FilmsContext>(options => options
						.UseLazyLoadingProxies()
						.UseNpgsql(postgresConfig[nameof(PostgresConfig.ConnectionString)]));


			var mongoConfig = _configuration.GetSection(nameof(MongoConfig));

			services.Configure<MongoConfig>(mongoConfig);

			services.AddSingleton<IMongoRepositiory, MongoRepositiory>();
			services.AddTransient<IFilmService, FilmService>();


			//var appSettings = _configuration.GetSection("AppSettings");
			//services.Configure<AppSettings>(appSettings);

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
			});
		}
	}
}