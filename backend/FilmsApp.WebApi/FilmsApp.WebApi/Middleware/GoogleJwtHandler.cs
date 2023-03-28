using FilmsApp.WebApi.Configuration;
using FilmsApp.WebApi.Services.Interfaces;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace FilmsApp.WebApi.Middleware
{
	public class GoogleJwtHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{

        private readonly IUserService _userService;
        private readonly ILogger<GoogleJwtHandler> _logger;
        private readonly AuthenticationConfiguration _authConfiguration;

		public GoogleJwtHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IUserService userService,
            IOptions<AuthenticationConfiguration> authConfiguration)
            : base(options, logger, encoder, clock)
		{
            _userService = userService;
            _logger = logger.CreateLogger<GoogleJwtHandler>();
            _authConfiguration = authConfiguration?.Value
                ?? throw ArgumentNullException(nameof(authConfiguration));
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }
            if(!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue? headerValue))
            {
                return AuthenticateResult.NoResult();
            }


			try
			{
                GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

                settings.Audience = new List<string>() { _authConfiguration.Google.ClientId };

                GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(headerValue.ToString(),
                        settings).Result;

                var user = await _userService.GetUserAsync(payload.Email);

                if(user == null)
                {
                    await _userService.CreateUserAsync(payload.Email);
                
                }

                var claims = new[] { new Claim(payload.Email, "username found in db") };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                _logger.LogInformation($"Пользователь: {payload.Email} успешно авторизирован");
                return AuthenticateResult.Success(ticket);
            }
            catch(Exception ex)
			{
                _logger.LogError(ex, "Ошибка во врема авторизации пользователя");
                return AuthenticateResult.NoResult();

            }
        }
	}
}
