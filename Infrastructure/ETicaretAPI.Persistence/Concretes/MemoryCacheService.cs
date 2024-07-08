using ETicaretApi.Application.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memorycache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memorycache = memoryCache;

        }
        public T? Get<T>(string key)
        {
           _memorycache.TryGetValue<T>(key, out var value);
            return value;
        }

        public bool Remove(string key)
        {
            _memorycache.Remove(key);
            return true;
        }

        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            var cacheEntry = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromSeconds(1),
            };
            _memorycache.Set<T>(key, value, cacheEntry);
        }
        
    }
}
