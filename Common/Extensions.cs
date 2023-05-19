using System.Runtime.CompilerServices;
using Common.Dispatcher;
using Common.Dispatcher.CommandProcessor;
using Common.Dispatcher.QueryProcessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class Extensions
{
    public static void RegisterDispatcher(this IServiceCollection services)
    {
        services.AddSingleton<IDispatcher, Dispatcher.Dispatcher>();
    }
    public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandlerAsync<>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandlerAsync<,>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandler<>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(ICommandHandler<,>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));
        }

        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(IQueryHandlerAsync<,>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));

            services.Scan(scan => scan
                                  .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                                  .AddClasses(classes =>
                                          classes.AssignableTo(typeof(IQueryHandler<,>))
                                                 .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                                  .AsSelfWithInterfaces()
                                  .WithLifetime(ServiceLifetime.Transient));
        }
        
        public static void UseSwaggerCommon(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }
}