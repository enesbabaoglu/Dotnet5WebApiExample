# Dotnet5WebApiExample

## 1 - Redis Implementation

   - Docker Install (https://docs.docker.com/desktop/)
   - docker pull redis ( https://hub.docker.com/_/redis )
   - Command To Start Redis Container : docker run --name your_containerName -p your_PortNumber:6379 -d redis
   - docker start your_container_name
   - docker exec -it your_docker_container_name redis-cli
   - Install-Package StackExchange.Redis.Extensions.AspNetCore
   - Install-Package StackExchange.Redis.Extensions.Newtonsoft
   - redis tag added appsettings.json 
   - register startup.cs
   - Create Interface and Service for Redis
   - Use RedisTestController

## 2 - Log4Net Implementation

   - "**Microsoft.Extensions.Logging.Log4Net.AspNetCore**" nuget package added project
   - Added *ConfigureLogging* in **Program.cs**
   - And Inject ILogger interface in class like RedisTestController.cs and use it. (**exmpl : _logger.LogInformation("example")**)