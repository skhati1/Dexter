using Dexter.BusinessLogic;
using Dexter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    public class StatsController : Controller
    {
        private readonly DexterDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private DexterGraphData _data;

        public StatsController(ILogger<HomeController> logger, DexterDbContext context, DexterGraphData data)
        {
            _logger = logger;
            _context = context;
            _data = data;
        }
        public IActionResult Index()
        {
            var allPokemons = _context.Pokemons.ToList();
            Statistics result = new Statistics();

            // Top Ten Fastest Legendary Pokemon 
            result.AddDexterChart(_data.GetTenFastestLegendaryPokemon());

            // Distribution of Primary Types across all Pokemon
            result.AddDexterChart(_data.GetTypePercentDistribution());

            // Top Ten Pokemon with most weaknesses
            result.AddDexterChart(_data.GetWeakestPokemonByType());

            return View(result);
        }
    }
}
