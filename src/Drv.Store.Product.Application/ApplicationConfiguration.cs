using System.Reflection;
using Drv.Store.Product.Application.Behaviors;
using Drv.Store.Shared.Infrastructure.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Drv.Store.Product.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(ApplicationConfiguration).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}