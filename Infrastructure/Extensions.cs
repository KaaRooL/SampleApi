using Core.Repositories;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.EntityFramework;
using Infrastructure.Firebase;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        });

        
        AddFirebase(services, configuration);

        services.AddScoped<ISampleRepository, SampleRepository>();
        
        
        return services;
        
        
    }

    private static void AddFirebase(IServiceCollection services, IConfiguration configuration)
    {
        var filePath = configuration.GetSection("Firebase:KeyPath");
        var firebase = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(filePath.Value),
        });

        
        services.AddSingleton(firebase);
        services.AddScoped<FirebaseAuthenticationFunctionHandler>();

        services.AddAuthentication()
                .AddScheme<FirebaseAuthenticationOptions, FirebaseAuthenticationHandler>(
                        JwtBearerDefaults.AuthenticationScheme, _ => { });
    }

    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        return app;
    }
}