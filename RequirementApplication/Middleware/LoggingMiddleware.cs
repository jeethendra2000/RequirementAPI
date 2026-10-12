namespace RequirementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;

            _logger.LogInformation("Incoming HTTP request: {Method} {Path}", method, path);
            Console.WriteLine($"[{DateTime.Now}] {context.Request.Method} {context.Request.Path}");

            await _next(context);
        }
    }
}
