using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
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
using Edufund.Infrastructure.Config;
using NLog.Web;
using Edufund.Infrastructure.Services.Abstractions;
using Edufund.Infrastructure.Services.Implementations;
using Edufund.Infrastructure.UnitofWork;
using Edufund.Data.Databasefactory;
using Edufund.Data;
using Edufund.Data.DatabaseManager;
using Edufund.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Edu.WebApi
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
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
            EntityFrameworkConfiguration.ConfigureService(services, Configuration);
            services.AddSingleton<IJwtFactory, JwtFactory>();
            var jwtsectionOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            AuthConfiguration.ConfigureAuth(services, jwtsectionOptions, _signingKey);
            ConfigurationOptions.ConfigureService(services, Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            IOCConfiguration.ConfigureServices(services);
            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            AutoMapperConfiguration.Configure();
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
                app.UseExceptionMiddleware();
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseExceptionHandler();
                app.UseExceptionMiddleware();
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseCors("AllowAllHeaders");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device Api v1.0");
            });
            env.ConfigureNLog("nlog.config");
        }
    }
}
