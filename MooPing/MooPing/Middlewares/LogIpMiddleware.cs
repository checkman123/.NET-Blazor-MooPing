namespace MooPing.Middlewares
{
    public class LogIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogIpMiddleware> _logger;

        public LogIpMiddleware(RequestDelegate next, ILogger<LogIpMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation($"IP Address: {ipAddress}");

            await _next(context);
        }
    }
}
