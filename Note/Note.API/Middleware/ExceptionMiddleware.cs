using System.Net;
using System.Text.Json;
using Note.Infrastructure.Exception;

namespace Note.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleAsync(context, exception);
            }
        }
        
        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case NotepadNotFoundException notepadNotFoundException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new {ErrorMessge = notepadNotFoundException.ErrorMessage });
                    break;
                case Exception ex:
                    result = JsonSerializer.Serialize(new {ErrorMessge = exception.Message });
                    break;    
            }

            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(result);
        }
    }
}