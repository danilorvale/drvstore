using Drv.Store.Order.Application.Abstractions;
using Drv.Store.Order.Domain.Abstractions;
using Drv.Store.Order.Infrastructure.Database;
using Drv.Store.Order.Infrastructure.Service;
using Drv.Store.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Drv.Store.Order.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductService, ProductService>();

        services.AddRefitClient<IProductApi>().ConfigureHttpClient((serviceProvider, httpClient) =>
        {
            httpClient.BaseAddress = new Uri(configuration["apiProduct"] ?? string.Empty);

            if(httpClient.BaseAddress.AbsoluteUri == string.Empty)
                throw new ArgumentException("API Product URI is empty");
        });

        return services;
    }
}