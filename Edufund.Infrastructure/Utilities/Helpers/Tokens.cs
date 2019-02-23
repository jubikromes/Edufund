using Edufund.Infrastructure.Models;
using Edufund.Infrastructure.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Utilities.Helpers
{
    public static class Tokens
    {
        public static async Task<TokenViewModel> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new TokenViewModel
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };
            //return JsonConvert.SerializeObject(response, serializerSettings);
            return response;
        }
    }
}
