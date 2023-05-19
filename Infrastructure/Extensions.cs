using Core.Repositories;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Class1
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        });

        services.AddTransient<ISampleRepository, SampleRepository>();
        return services;
    }
    
    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        return app;
    }
}