using DotNet5WebApiExample.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5WebApiExample.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DotNet5WebApiExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyAllowOrigin = "_myAllowOrigin";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet5WebApiExample", Version = "v1" });
            });
            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>((options) => Configuration.GetSection("Redis").Get<RedisConfiguration>());
            
            services.AddDbContext<WebApiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Data Source=DESKTOP-AJT2GI5; Initial Catalog=WebApiDb;Integrated Security=SSPI;")));
           
            services.AddSingleton<IRedisCacheService, RedisCacheService>();

            services.AddCors(options => options.AddDefaultPolicy(
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200");

                    //.WithMethods("GET","POST","DELETE") 
                    //.AllowAnyOrigin()
                    //.AllowAnyHeader()
                    //.AllowAnyMethod();
                }
                ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet5WebApiExample v1"));
            }

            app.UseRouting();
            
            app.UseCors();//Default policy eklendi?i i?in policy ismi eklemeye gerek yok.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
