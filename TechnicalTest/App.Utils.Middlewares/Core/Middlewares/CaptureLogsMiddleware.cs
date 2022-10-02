using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace App.Utils.Middlewares.Core.Middlewares
{
    public class CaptureLogsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CaptureLogsMiddleware> _logger = null!;

        public CaptureLogsMiddleware(RequestDelegate next, ILogger<CaptureLogsMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext?.Request?.Path;
            var method = httpContext?.Request?.Method;

            _logger.LogInformation($"Calling the endpoint {method} - {path}");
            await _next(httpContext);
            _logger.LogInformation($"Called the endpoint {method} - {path}");
        }
    }

    public static class CaptureLogsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCaptureLogsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CaptureLogsMiddleware>();
        }
    }
}
