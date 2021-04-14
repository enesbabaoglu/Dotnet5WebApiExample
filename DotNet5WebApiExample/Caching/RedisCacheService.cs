using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5WebApiExample.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IRedisCacheClient _redisCacheClient;
        public RedisCacheService(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }
        public Task<string> GetSetCache(string key, string value)
        {
           _redisCacheClient.GetDbFromConfiguration().AddAsync<string>(key, value, DateTimeOffset.Now.AddMinutes(2));
            return GetValueOfKey(key);
        }
        public Task<Object> GetSetObjectCache<Object>(string key, Object tObject)
        {
            _redisCacheClient.GetDbFromConfiguration().AddAsync<Object>(key, tObject, DateTimeOffset.Now.AddHours(1));
             
            return _redisCacheClient.GetDbFromConfiguration().GetAsync<Object>(key);
        }
        public Task<IEnumerable<string>> SearchKey(string key)
        {
            var allKeys = _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync($"*{key}*");
            return allKeys;
        }
        public Task<string> GetValueOfKey(string key)
        {
            var allKeys = _redisCacheClient.GetDbFromConfiguration().GetAsync<string>(key);
            return allKeys;
        }
     
        public void Remove(string key)
        {
            _redisCacheClient.GetDbFromConfiguration().RemoveAsync(key);
        }
        public void Clear()
        {
           _redisCacheClient.GetDbFromConfiguration().FlushDbAsync();
        }
    }
}
