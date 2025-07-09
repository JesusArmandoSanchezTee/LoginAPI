using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ServiceExtensions).Assembly);
        services.AddMediatR(typeof(ServiceExtensions).Assembly);
    }
}