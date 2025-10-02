using FluentValidation;
using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace BloodTrack.Api.Middlewares
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
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Uma exceção não tratada ocorreu: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";


            var statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = "Ocorreu um erro interno no servidor";
            var errorDetails = new List<string> { errorMessage };

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = "Dados inválidos";
                    errorDetails = validationException.Errors
                        .Select(error => $"{error.PropertyName} : {error.ErrorMessage}")
                        .ToList();
                    break;

                case DbUpdateException dbUpdateException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = "Falha de integridade de dados. O registro pode já existir ou contém dados inválidos.";
                    errorDetails = new List<string> { errorMessage };

                    if (context.RequestServices.GetService<IWebHostEnvironment>()?.IsDevelopment() == true)
                    {
                        errorDetails.Add(dbUpdateException.InnerException?.Message ?? "Detalhe de erro de DB indisponível.");
                    }
                    break;

                default:
                    if (context.RequestServices.GetService<IWebHostEnvironment>()?.IsProduction() == true)
                    {
                        errorDetails = new List<string> { "Ocorreu um erro interno. Tente novamente mais tarde." };
                    }
                    else
                    {
                        errorDetails.Add(exception.Message);
                    }
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = errorMessage,
                Errors = errorDetails
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

