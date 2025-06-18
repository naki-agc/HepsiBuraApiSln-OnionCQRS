using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext); // önce gel httpContexti geçitr hata alırsan exceptiona düşer
                // Eğer hata alınmazsa, normal akış devam eder.
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex); // Hata alındığında HandleExceptionAsync çağrılır.
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception); // Hata türüne göre durum kodu al
            httpContext.Response.ContentType = "application/json"; // Yanıt içeriği tipi JSON olarak ayarlanır
            httpContext.Response.StatusCode = statusCode; // Durum kodu ayarlanır


            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(x=> x.ErrorMessage), // ValidationException'dan gelen hatalar listeye eklenir
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }
            List<string> errors = new()
            {
                $"Hata mesajı :{exception.Message}", // Hata mesajı listeye eklenir
                $"Mesaj Açıklaması:{exception.InnerException?.ToString()}",// İç hata mesajı listeye eklenir (eğer varsa)

            };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode,

            }.ToString());

        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest, // 400 Bad Request
                NotFoundException => StatusCodes.Status404NotFound, // 404 Not Found
                ValidationException => StatusCodes.Status422UnprocessableEntity, // 422 Unprocessable Entity
                _ => StatusCodes.Status500InternalServerError // 500 Internal Server Error
            };
        
    }
}
