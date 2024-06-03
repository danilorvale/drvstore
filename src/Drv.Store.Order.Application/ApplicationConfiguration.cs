using System.Reflection;
using Drv.Store.Order.Application.Behaviors;
using Drv.Store.Order.Application.Order.Commands.Create;
using Drv.Store.Shared.Infrastructure.Authentication;
using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drv.Store.Order.Application;

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
        
        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.AddConsumer<CreateOrderConsumer>();
    
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(configuration["MessageBroker:Username"] ?? string.Empty);
                    h.Password(configuration["MessageBroker:Password"] ?? string.Empty);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}