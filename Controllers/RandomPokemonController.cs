using Dexter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    public class RandomPokemonController : Controller
    {
        private readonly DexterDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly Random _rand;

        public RandomPokemonController(ILogger<HomeController> logger, DexterDbContext context)
        {
            _logger = logger;
            _context = context;
            _rand = new Random();
        }
        public IActionResult Index()
        {
            var allPokemons = _context.Pokemons.ToList();
            var randomIndex = _rand.Next(0, allPokemons.Count() - 1);
            var randomPokemon = allPokemons.First(p => p.PokedexNumber == randomIndex);
            return View("Index", randomPokemon);
        }
    }
}
