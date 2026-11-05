using System.Text.Json;
using FluentValidation;
using InvenTracker.Application.Common;
using InvenTracker.Domain.Exceptions;

namespace InvenTracker.Server.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 404, Message = ex.Message });
            await context.Response.WriteAsync(message);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            await context.Response.WriteAsync(message);
        }
        catch (UnauthorizedException ex)
        {
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 401, Message = ex.Message });
            await context.Response.WriteAsync(message);
        }
        catch (ConflictException ex)
        {
            context.Response.ContentType = "application/json";
            var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 409, Message = ex.Message });
            await context.Response.WriteAsync(message);
        }
        catch (ForbiddenException ex)
        {
            context.Response.ContentType = "application/json";
            var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 403, Message = ex.Message });
            await context.Response.WriteAsync(message);
        }
        catch (Exception ex)
        {
           context.Response.ContentType = "application/json";
           var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 500, Message = ex.Message });
           await context.Response.WriteAsync(message);
        }
    }
}