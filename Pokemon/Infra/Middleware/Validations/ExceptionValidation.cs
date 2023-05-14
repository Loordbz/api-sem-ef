using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Infra.Middleware.Validations;

internal class ExceptionValidation
{
    public static (int statusCode, string details) SelectExceptionResponse(HttpContext httpContext, Exception exception)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var details = exception.Message;

        string exceptionSourceName = exception.GetType().Name;

        switch (exceptionSourceName)
        {
            case nameof(CustomException):
                statusCode = (int)((CustomException)exception).StatusCode;
                break;
        }

        return (statusCode, details);
    }
}