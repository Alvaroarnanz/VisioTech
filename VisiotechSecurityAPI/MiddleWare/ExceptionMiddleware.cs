using System.Net;
using System.Text.Json;

// la funcion de este midleware es envolver todas las solicitudes en un try. Esto nos evitar colocar try catch en cada uno delos endpoints
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
            // Envuelve la solicitud en un try
            await _next(context);
        }
        catch (Exception ex)
        {
            // Manejar las excepciones globalmente
            await HandleExceptionAsync(context, ex);
        }
    }

    // Caso haya alguna excepcion, el tratamiento esta padronizado devolviendo un error 500.
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An unexpected error occurred. Please try again later.",
            Detailed = exception.Message 
        };

        var jsonResponse = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(jsonResponse);
    }
}
