using Shop.API.Responses;
using System.Text.Json;

namespace Shop.API.Middlewares
{
    public class ResponseWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseWrappingMiddleware> _logger;

        public ResponseWrappingMiddleware(RequestDelegate next, ILogger<ResponseWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var originalBodyStream = context.Response.Body;
                using var memStream = new MemoryStream();
                context.Response.Body = memStream;

                await _next(context);

                memStream.Position = 0;
                var responseBody = await new StreamReader(memStream).ReadToEndAsync();
                memStream.Position = 0;
                context.Response.Body = originalBodyStream;

                object? data = null;
                if (!string.IsNullOrWhiteSpace(responseBody) &&
                    context.Response.ContentType?.Contains("application/json") == true)
                {
                    try
                    {
                        data = JsonSerializer.Deserialize<object>(responseBody);
                    }
                    catch
                    {
                        data = responseBody;
                    }
                }

                var response = new Response<object>
                {
                    Succeeded = context.Response.StatusCode is >= 200 and < 300,
                    Message = context.Response.StatusCode switch
                    {
                        200 => "Success",
                        201 => "Created",
                        400 => "Bad Request",
                        401 => "Unauthorized",
                        403 => "Forbidden",
                        404 => "Not Found",
                        409 => "Conflict",
                        500 => "Internal Server Error",
                        _ => null
                    },
                    Errors = context.Response.StatusCode is >= 400
                        ? new List<string> { responseBody }
                        : null,
                    Data = context.Response.StatusCode is >= 200 and < 300 ? data : null
                };

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = new Response<object>
                {
                    Succeeded = false,
                    Message = "Internal Server Error",
                    Errors = new List<string> { ex.Message },
                    Data = null
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

}
