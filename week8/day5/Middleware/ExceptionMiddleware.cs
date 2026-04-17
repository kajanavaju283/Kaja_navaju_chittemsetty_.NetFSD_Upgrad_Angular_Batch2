using System;                          // ✅ REQUIRED
using System.Net;
using System.Text.Json;
using Week8_day5.Exceptions;
using Week8_day5.Models;

namespace Week8_day5.Middleware   // ✅ also fixed namespace (remove .API)
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            if (ex is NotFoundException)
                status = HttpStatusCode.NotFound;
            else if (ex is BadRequestException)
                status = HttpStatusCode.BadRequest;

            var response = new ErrorResponse
            {
                Message = ex.Message,
                StatusCode = (int)status,
                Timestamp = DateTime.UtcNow   // ✅ NOW WORKS
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(json);
        }
    }
}
