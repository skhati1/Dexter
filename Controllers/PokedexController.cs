using Dexter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    [Route("[Controller]")]
    public class PokedexController: Controller
    {
        private readonly DexterDbContext _context;
        private readonly ILogger<HomeController> _logger;

        
        public PokedexController(ILogger<HomeController> logger, DexterDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Index([FromRoute] int? id) {
            if (id == null) return View();
            var result = _context.Pokemons.FirstOrDefault(p => p.pokedex_number == id);

            if (result == null) return View();

            return View(result);
        }

    }
}
