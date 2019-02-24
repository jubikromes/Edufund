using Edufund.Data.Context;
using Edufund.Data.Identity;
using Edufund.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.Configuration
{
    public static class AuthenticationConfiguration
    {
       
        public static void ConfigureAuth(IServiceCollection services, IConfigurationSection jwtsectionOptions, SymmetricSecurityKey _signingKey)
        {

            services.Configure<JwtIssuerOptions>(options => {
                options.Issuer = jwtsectionOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtsectionOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtsectionOptions[nameof(JwtIssuerOptions.Issuer)],
                ValidateAudience = true,
                ValidAudience = jwtsectionOptions[nameof(JwtIssuerOptions.Issuer)],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options => {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions => {
                configureOptions.ClaimsIssuer = jwtsectionOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });
            var builder = services.AddIdentity<EduUser, EduRole>(p => {
                p.Password.RequireDigit = false;
                p.Password.RequireLowercase = false;
                p.Password.RequireUppercase = false;
                p.Password.RequireNonAlphanumeric = false;
                p.Password.RequiredLength = 6;
            });
            //var builder = services.AddIdentityCore<EduUser>(o =>
            //{
            //    // configure identity options
            //    o.Password.RequireDigit = false;
            //    o.Password.RequireLowercase = false;
            //    o.Password.RequireUppercase = false;
            //    o.Password.RequireNonAlphanumeric = false;
            //    o.Password.RequiredLength = 6;
            //});
            builder = new IdentityBuilder(builder.UserType, typeof(EduRole), builder.Services);
            builder.AddEntityFrameworkStores<EduFundContext>().AddDefaultTokenProviders();

            //services.AddAuthorization(options => {
            //    options.AddPolicy(Constants.Strings.JwtClaimIdentifiers.Pol_ApiAccess_Key, policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.Pol_ApiAccess));
            //    options.AddPolicy(Constants.Strings.JwtClaimIdentifiers.Pol_ApproveVehicle_Key, policy => policy.RequireClaim(Constants.Strings.JwtClaims.Pol_ApproveVehicle));
            //});
        }
    }
}
