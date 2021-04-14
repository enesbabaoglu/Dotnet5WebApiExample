using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5WebApiExample.Caching
{
    public interface IRedisCacheService
    {
        Task<string> GetSetCache(string key, string value);

        Task<Object> GetSetObjectCache<Object>(string key, Object tObject);

        Task<IEnumerable<string>> SearchKey(string key);
        Task<string> GetValueOfKey(string key);
        //Task<T> GetObjectOfKey<T>(string key, Student tObject);
        void Remove(string key);

        void Clear();
       
    }
}
