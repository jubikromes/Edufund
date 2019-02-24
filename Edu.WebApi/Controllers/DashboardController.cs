using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DashboardController : BaseController
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return Json("Welcome to the Educollect Dashboard");
        }
        [Route("loginreports")]
        public IActionResult LoginReports()
        {
            return Json("The golden login reports");
        }
    }
}