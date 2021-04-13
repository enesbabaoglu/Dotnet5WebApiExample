using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5WebApiExample.Caching
{
    public interface IRedisCacheService
    {
        Task<string> GetSetCache(string key, string value);

        Task<Object> GetSetObjectCache(string key, Object tObject);

        Task<IEnumerable<string>> SearchKey(string key);
        Task<string> GetValueOfKey(string key);
        Task<Object> GetObjectOfKey(string key, Object tObject);
        void Remove(string key);

        void Clear();
       
    }
}
