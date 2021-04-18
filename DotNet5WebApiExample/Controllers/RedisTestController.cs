using DotNet5WebApiExample.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5WebApiExample.Entities;

namespace DotNet5WebApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisTestController : ControllerBase
    {

        private readonly ILogger<RedisTestController> _logger;
        private readonly IRedisCacheService _redisCacheService;
        public RedisTestController(IRedisCacheService redisCacheService, ILogger<RedisTestController> logger)
        {
            _logger = logger;
            _redisCacheService = redisCacheService;
        }

        [HttpPost]
        [Route("get-set-cache")]
        public async Task<IActionResult> GetSetCache(string key,string value)
        {
            _logger.LogInformation($"The key was adding cache = {key}");
            var keyValue = await _redisCacheService.GetSetCache(key, value);
        
            return Ok(keyValue);
        }

        [HttpGet]
        [Route("get-set-type-cache")]
        public async Task<IActionResult> GetSetObjectCach()
        {
            var student = new Student
            {
                Id = 1,
                Name = "naveen",
                ContactDetails = new ContactDetails
                {
                    Email = "naveen@gmail.com",
                    Phone = "1234567890"
                }
            };
            var ObjValue= await  _redisCacheService.GetSetObjectCache<Student>("student", student);
            return Ok(ObjValue);
        }
  
        [HttpPost]
        [Route("search-cache-keys")]
        public async Task<IActionResult> SearchKeys(string key)
        {
            var allKeys = await _redisCacheService.SearchKey(key);
            return Ok(allKeys);
        }

        [HttpPost]
        [Route("remove")]
        public IActionResult Remove(string key)
        {
             _redisCacheService.Remove(key);
            return Ok($"{key} - silindi.");
        }

   

        [HttpGet]
        [Route("clear")]
        public IActionResult Clear()
        {
            _redisCacheService.Clear();
            return Ok("Cleared.");
        }
    }


}
