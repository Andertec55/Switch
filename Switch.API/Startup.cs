﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Switch.Infra.Data.Context;
namespace Switch.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("SwitchDB");
            services.AddDbContext<SwitchContext>(option => option.UseLazyLoadingProxies()
                                                    .UseMySql(conn, m => m.MigrationsAssembly("Switch.Infra.Data")));
            services.AddMvcCore();
        }

        private Action<DbContextOptionsBuilder> UseMySql(string conn, Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
