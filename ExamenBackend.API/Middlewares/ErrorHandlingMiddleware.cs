
using ExamenBackend.Application.Models;
using ExamenBackend.Domain.Exceptions;
using FluentValidation;
using System.Text.Json;

namespace ExamenBackend.API.Middlewares;

public class ErrorHandlingMiddleware(
    ILogger<ErrorHandlingMiddleware> logger    
) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch(SaveUserException ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
        }
        catch(ValidationException ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest, ex.Errors);
        }
        catch(NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode, object? data = null)
    {
        logger.LogError(ex, ex.Message);

        var response = new ApiResponse<object>
        {
            Success = false,
            Message = ex.Message,
            Data = data
        };

        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}
