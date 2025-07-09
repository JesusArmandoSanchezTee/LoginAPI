using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Host.Middlewares;

public static class Startup
{
    public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>()
            .Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = actionContext =>
                    throw new ValidationException("Petición incorrecta", actionContext.ModelState.Values
                        .SelectMany(r => r.Errors)
                        .Where(f => f != null)
                        .Select(x => x.ErrorMessage)
                        .ToList()));
        return services;
    }

    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionMiddleware>();

}