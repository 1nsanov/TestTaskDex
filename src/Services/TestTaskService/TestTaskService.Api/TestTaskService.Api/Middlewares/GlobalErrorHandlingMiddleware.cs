using System.Net;
using System.Text.Json;
using FluentValidation;
using TestTaskService.Application.Exceptions;

namespace TestTaskService.Api.Middlewares;

/// <summary>
/// Глобальный перехватчик ошибок
/// </summary>
public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException ex)
        {
            await HandleExceptionAsync(HttpStatusCode.NotFound, context, ex);
        }
        catch (ValidationException ex)
        {
            await HandleExceptionAsync(HttpStatusCode.BadRequest, context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(HttpStatusCode.InternalServerError, context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpStatusCode status, HttpContext context, Exception ex)
    {
        var exceptionResult = JsonSerializer.Serialize(new { error = ex.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(exceptionResult);
    }
}