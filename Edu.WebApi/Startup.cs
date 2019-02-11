using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Edufund.Infrastructure.Repositories.Abstractions;
using Edufund.Infrastructure.Repositories.Implementations;
using AutoMapper;
using Edufund.Data.Configuration;
using Edu.WebApi.Configuration;
using Microsoft.EntityFrameworkCore;
using Edufund.Data.Context;
using Edufund.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Edu.WebApi.Middleware;

namespace Edu.WebApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationOptions.ConfigureService(services, Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));

            EntityFrameworkConfiguration.ConfigureService(services, Configuration);
            services.AddIdentity<EduUser, EduRole>().AddEntityFrameworkStores<EduFundContext>().AddDefaultUI().AddDefaultTokenProviders();


            services.AddAutoMapper();


            //services.AddTransient<IEmailSender, EmailSender>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //order
            // 1. Exception Handling
            // 2 . HTTP Strict Transport Security Protocol
            // 3 HTTPS redirection
            // 4. Static file server
            // 5. Cookie policy enforcement
            // 6. Authentication
            // 7. Session
            // 8. MVC
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseExceptionHandler();
                app.UseExceptionMiddleware();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
