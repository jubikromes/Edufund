using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    public class DashboardController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}