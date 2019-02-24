using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edu.WebApi.Models;
using Edufund.Infrastructure.Models;
using Edufund.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAccountService _accountSvc;
        public AuthController(IAccountService accountSvc)
        {
            _accountSvc = accountSvc;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegistrationModel model)
        {
            var response = new BaseResponseModel { };
            response = await _accountSvc.RegisterAsync(model);
            return Json(response);
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]CredentialsModel model)
        {
            var response = new ResponseModel<TokenViewModel> { };
            response = await _accountSvc.LoginAsync(model);
            return Json(response);
        }
    }
}