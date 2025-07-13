using Mariusz.Piotrowski.Application.Common.Exceptions;
using System.Text.Json;

namespace Mariusz.Piotrowski.Api.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            var response = httpContext.Response;

            object result;
            switch (ex)
            {
                case BadRequestException badRequest:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    result = new
                    {
                        StatusCode = response.StatusCode,
                        Message = badRequest.Message,
                        Errors = badRequest.ValidationErrors
                    };
                    break;

                case NotFoundException notFound:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    result = new
                    {
                        StatusCode = response.StatusCode,
                        Message = notFound.Message
                    };
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    result = new
                    {
                        StatusCode = response.StatusCode,
                        Message = ex.Message,
                        Details = ex.InnerException?.Message
                    };
                    break;
            }

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
