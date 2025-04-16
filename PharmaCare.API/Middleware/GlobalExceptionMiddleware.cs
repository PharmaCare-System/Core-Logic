using System.Text.Json;

namespace PharmaCare.API.Middleware
{
	public class GlobalExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Something went wrong: {Message}", ex.Message);

				context.Response.StatusCode = 500;
				context.Response.ContentType = "application/json";
				var response = new
				{
					Message = "Something went wrong, please try again later.",
					Details = ex.Message
				};
				await context.Response.WriteAsJsonAsync(response);
			}
		}
	}
}
