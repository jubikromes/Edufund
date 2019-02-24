using Edufund.Infrastructure.Utilities.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.Configuration
{
    public static class PolicyAuthConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.Strings.JwtClaimIdentifiers.Pol_ApiAccess_Key, policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.Pol_ApiAccess));
            });
        }
    }
}
