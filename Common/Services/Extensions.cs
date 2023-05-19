/*
 * Copyright (C) 2022 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */

using Microsoft.Extensions.DependencyInjection;

namespace Common.Services
{
    public static class Extensions
    {
        public static void AddScopeServices(this IServiceCollection services)
        {
            services.Scan(s =>
                    s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                     .AddClasses(c => c.AssignableTo(typeof(IScopedService))
                                       .WithoutAttribute(typeof(DecoratorAttribute)))
                     .AsImplementedInterfaces()
                     .WithScopedLifetime());
        }

        public static void AddSingleServices(this IServiceCollection services)
        {
            services.Scan(s =>
                    s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                     .AddClasses(c => c.AssignableTo(typeof(ISingleService))
                                       .WithoutAttribute(typeof(DecoratorAttribute)))
                     .AsImplementedInterfaces()
                     .WithSingletonLifetime());
        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.Scan(s =>
                    s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                     .AddClasses(c => c.AssignableTo(typeof(ITransientService))
                                       .WithoutAttribute(typeof(DecoratorAttribute)))
                     .AsImplementedInterfaces()
                     .WithTransientLifetime());
        }
    }
}

