using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    public class RandomPokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
