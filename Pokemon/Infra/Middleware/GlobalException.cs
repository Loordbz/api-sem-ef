using Domain.Exceptions;
using Infra.Middleware.Validations;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Infra.Middleware;

public class GlobalException : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try { await next(context); }
        catch (Exception e) { await HandleExceptionsAsync(context, e); }
    }


    private static Task HandleExceptionsAsync(HttpContext context, Exception exception)
    {
        var exceptionResult = ExceptionValidation.SelectExceptionResponse(context, exception);

        var result = JsonSerializer.Serialize(new DefaultGlobalException
        {
            Data = default,
            Success = false,
            Notification = exceptionResult.details
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exceptionResult.statusCode;

        return context.Response.WriteAsync(result);
    }
}