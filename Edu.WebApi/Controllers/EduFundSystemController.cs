using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edufund.Infrastructure.DTO;
using Edufund.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    [Route("api/edufundsystemapi")]
    public class EduFundSystemController : BaseController
    {
        private readonly IEduFundSystemService _eduFundSystem;
        public EduFundSystemController(IEduFundSystemService eduFundSystem)
        {
            _eduFundSystem = eduFundSystem;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("createedufundsystem")]
        public async Task<IActionResult> CreateEduFundSystem([FromBody]EduFundSystemDto systemDto)
        {
            var result = await _eduFundSystem.CreateEduFundSystem(systemDto);
            return Json(result);
        }
    }
}