using FilmsApp.Data;
using FilmsApp.Data.Configuration;
using FilmsApp.Data.Mongo;
using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.Services;
using FilmsApp.WebApi.Services.Interfaces;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
			services.AddTransient<ICountryService, CountryService>();
			services.AddTransient<IFilmTypeService, FilmTypeService>();


			var appSettings = _configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettings);

			//services.AddAuthentication(options =>
			//{
			//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//})
		 //  .AddJwtBearer(options =>
		 //  {
			//   options.Authority = "https://accounts.google.com";
			//   options.Audience = _configuration["Authentication:Google:ClientId"];
		 //  });
		   //.AddGoogleOpenIdConnect(options =>
		   //{
			  // options.ClientId = _configuration["Authentication:Google:ClientId"];
			  // options.ClientSecret = _configuration["Authentication:Google:ClientSecret"];
			  // options.SaveTokens = true;
		   //});

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseCors("CorsPolicy");

			app.UseHttpsRedirection();

			app.UseRouting();

			//app.UseAuthentication();

			//app.UseAuthorization();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
			});
		}
	}
}