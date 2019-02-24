using Edufund.Infrastructure.Utilities.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.Controllers
{
    [Authorize(Policy = Constants.Strings.JwtClaimIdentifiers.Pol_ApiAccess_Key, AuthenticationSchemes = "Bearer")]
    public class BaseController : Controller
    {

    }
}
