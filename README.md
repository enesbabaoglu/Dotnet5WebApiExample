# Dotnet5WebApiExample

GITHUB ACTIONS :
[![WEPAPI CI](https://github.com/enesbabaoglu/Dotnet5WebApiExample/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/enesbabaoglu/Dotnet5WebApiExample/actions/workflows/dotnet.yml)

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
   - Added log4net.config in project
   - And Inject ILogger interface in class like RedisTestController.cs and use it. (**exmpl : _logger.LogInformation("example")**)

## 3 - EntityFrameworkCore Implemantation 

   - Add Nuget Packages 
      - Microsoft.EntityFrameworkCore
      - Microsoft.EntityFrameworkCore.Design
      - Microsoft.EntityFrameworkCore.Tools
      - Microsoft.EntityFrameworkCore.SqlServer
   - Create **WebApiContext** in Repositories/Concrete
   - Add implementation *Startup.cs*
   - Create *IGenericRepository* interface for generic db action in Repository/Abstract
   - Create *GenericRepository* class and use WebApiContext in Repository/Concrete 
