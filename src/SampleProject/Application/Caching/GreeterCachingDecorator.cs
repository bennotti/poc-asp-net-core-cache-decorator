using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SampleProject.Core.InternalServices.Interfaces;
using SampleProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Infrastructure.Caching
{
    public class GreeterCachingDecorator<T>: IGreeterService where T: IGreeterService
    {
        private readonly IMemoryCache memoryCache;
        private readonly T inner;
        private readonly ILogger<GreeterCachingDecorator<T>> logger;

        public GreeterCachingDecorator(IMemoryCache memoryCache, T inner, ILogger<GreeterCachingDecorator<T>> logger)
        {
            this.memoryCache = memoryCache;
            this.inner = inner;
            this.logger = logger;
        }

        public async Task<GreeterListDto> List()
        {
            string key = "greeterLists";
            var itens = memoryCache.Get<GreeterListDto>(key);
            if (itens == null)
            {
                itens = await inner.List();
                logger.LogTrace("Cache miss for {CacheKey}", key);
                if (itens != null)
                {
                    logger.LogTrace("Setting itens in cache for {CacheKey}", key);
                    memoryCache.Set(key, itens, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                itens.FromMemory();
                logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return itens;
        }
    }
}
