// Copyright (C) 2023 Patco, LLC - All Rights Reserved.
// You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.

using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddDomainServices();

        return services;
    }

    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        
        return services;
    }
}