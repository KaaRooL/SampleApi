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

        
        AddFirebase(services);

        services.AddScoped<ISampleRepository, SampleRepository>();
        
        
        return services;
        
        
    }

    private static void AddFirebase(IServiceCollection services)
    {
        var firebase = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("C:/Firebase/commonproject-b0f95-firebase-adminsdk-16ti3-fdab7e9f8c.json"),
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