using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edufund.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    [Route("api/memberapi")]
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReferral(ReferralViewModel model)
        {
            return View();
        }
    }
}