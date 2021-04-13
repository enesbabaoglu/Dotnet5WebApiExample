using DotNet5WebApiExample.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("get-set-cache")]
        public async Task<IActionResult> GetSetCache()
        {

            var keyValue = await _redisCacheService.GetSetCache("myname", "enes");
        
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
            var ObjValue= await  _redisCacheService.GetSetObjectCache("student", student);
            return Ok(ObjValue);
        }
        [HttpGet]
        [Route("get-type-cache")]
        public async Task<IActionResult> GetObjectCach()
        {
            var student = new Student();
            var ObjValue = await _redisCacheService.GetObjectOfKey("student",student);
            return Ok(ObjValue);
        }
        [HttpGet]
        [Route("search-cache-keys")]
        public async Task<IActionResult> SearchKeys()
        {
            var allKeys = await _redisCacheService.SearchKey("stu");
            return Ok(allKeys);
        }

        [HttpGet]
        [Route("remove")]
        public async Task<IActionResult> Remove()
        {
            _redisCacheService.Remove("myname");
            return Ok();
        }

   

        [HttpGet]
        [Route("clear")]
        public async Task<IActionResult> Clear()
        {
            _redisCacheService.Clear();
            return Ok();
        }
    }


}
