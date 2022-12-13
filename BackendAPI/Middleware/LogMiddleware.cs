namespace BackendAPI.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;

        public LogMiddleware(RequestDelegate next, ILogService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string message = context.Request.Path;
            if (context.Request.ContentType is not null) message += "\n" + context.Request.ContentType;
            if (context.Request.Body is not null) message += "\n" + context.Request.Body;

            _logger.Log(message);

            await _next(context);

            var uniqueResponseHeaders = context.Response.Headers
                      .Select(x => x.Key)
                      .Distinct();

            _logger.Log(string.Join(", ", uniqueResponseHeaders));
        }
    }
}
