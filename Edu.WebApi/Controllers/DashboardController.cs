using Microsoft.AspNetCore.Mvc;

namespace Edu.WebApi.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}