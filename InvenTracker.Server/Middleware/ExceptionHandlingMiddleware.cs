using System.Text.Json;
using FluentValidation;
using InvenTracker.Application.Common;
using InvenTracker.Domain.Exceptions;
using Serilog;
using Serilog.Formatting.Json;

namespace InvenTracker.Server.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware>  logger)
    {
        _next = next;
        _logger = logger;
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
            context.Response.StatusCode = 404;
            _logger.LogError(ex, message);
            await context.Response.WriteAsync(message);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            context.Response.StatusCode = 400;
            _logger.LogError(ex, message);
            await context.Response.WriteAsync(message);
        }
        catch (UnauthorizedException ex)
        {
            context.Response.ContentType = "application/json";
            var message = JsonSerializer.Serialize(new ErrorResponse { StatusCode = 401, Message = ex.Message });
            context.Response.StatusCode = 401;
            _logger.LogError(ex, message);
            await context.Response.WriteAsync(message);
        }
        catch (ConflictException ex)
        {
            context.Response.ContentType = "application/json";
            var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 409, Message = ex.Message });
            context.Response.StatusCode = 409;
            _logger.LogError(ex, message);
            await context.Response.WriteAsync(message);
        }
        catch (ForbiddenException ex)
        {
            context.Response.ContentType = "application/json";
            var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 403, Message = ex.Message });
            context.Response.StatusCode = 403;
            _logger.LogError(ex, message);
            await context.Response.WriteAsync(message);
        }
        catch (Exception ex)
        {
           context.Response.ContentType = "application/json";
           var message= JsonSerializer.Serialize(new ErrorResponse { StatusCode = 500, Message = ex.Message });
           context.Response.StatusCode = 500;
           _logger.LogError(ex, message);
           await context.Response.WriteAsync(message);
        }
    }
}