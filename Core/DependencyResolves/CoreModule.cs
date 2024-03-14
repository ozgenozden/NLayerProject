using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

using System.Diagnostics;
using Core.Utilities.IoC;
using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;

namespace Core.DependencyResolves
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {

            
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<Stopwatch>();
        }
    }

    
}

