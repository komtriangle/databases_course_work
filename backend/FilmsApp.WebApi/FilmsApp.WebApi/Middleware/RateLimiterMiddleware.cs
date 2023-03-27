using FilmsApp.WebApi.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FilmsApp.WebApi.Middleware
{
    public class RateLimiterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;
        private readonly RateLimiterConfig _rateLimiterConfig;


        public RateLimiterMiddleware (RequestDelegate next,
            IDistributedCache distributedCache,
            IOptions<RateLimiterConfig> rateLimiterConfigOptions)
        {
            _next = next;

            _cache = distributedCache ??
                    throw new ArgumentNullException(nameof(distributedCache));

            if (rateLimiterConfigOptions?.Value == null)
            {
                throw new ArgumentNullException(nameof(rateLimiterConfigOptions));
            }

            _rateLimiterConfig = rateLimiterConfigOptions.Value;

            _distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _rateLimiterConfig.WindowLength
            };
        }

        public async Task InvokeAsync (HttpContext context)
        {
            string clientIPAddress = context.Connection.RemoteIpAddress.ToString();

            List<DateTime> clientRequests = await GetClientRequsts(clientIPAddress);

            clientRequests = clientRequests.Where(r => r > DateTime.UtcNow.Add(-_rateLimiterConfig.WindowLength))
                .ToList();

            if(clientRequests.Count >= _rateLimiterConfig.MaxRequestsPerWindow)
			{
                context.Response.StatusCode = 429;
                return;
            }

            clientRequests.Add(DateTime.UtcNow);

            await SetClientRequests(clientIPAddress, clientRequests);

            await _next(context);
        }

        private async Task<List<DateTime>> GetClientRequsts(string ip)
		{
            string cacheValue = await _cache.GetStringAsync(ip);

            if(cacheValue == null)
			{
                return new List<DateTime> { };
			}

            return JsonConvert.DeserializeObject<List<DateTime>>(cacheValue);
		}

        private async Task SetClientRequests(string ip, List<DateTime> requests)
		{
            await _cache.SetStringAsync(ip, JsonConvert.SerializeObject(requests), _distributedCacheEntryOptions);
		}
    }
    

}
