using System.Net;
using System.Text.Json;

namespace CL_FrameworksDrivers_API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pasa al siguiente middleware en la tubería
                await _next(context);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver una respuesta adecuada
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // personalizamos la respuesta del error
            var response = context.Response;
            response.ContentType = "application/json";

            // formateamos el codigo respuesta
            var statusCode = HttpStatusCode.InternalServerError; // 500 si no es manejada específicamente
            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.Message
            });

            response.StatusCode = (int)statusCode;
            return response.WriteAsync(result);
        }
    }
}
