using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
