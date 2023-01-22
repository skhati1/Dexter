using Dexter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dexter.Controllers
{
    public class StatsController : Controller
    {
        private readonly DexterDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public StatsController(ILogger<HomeController> logger, DexterDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var statistics = GetStatisticsToShow();
            return View(statistics);
        }
        private Statistics GetStatisticsToShow()
        {
            var allPokemons = _context.Pokemons.ToList();
            Statistics result = new Statistics();

            // Distribution of Primary Types across all Pokemon
            result.AddDexterChart(GetTypePercentDistribution(allPokemons));

            // Top Ten Pokemon with most weaknesses
            result.AddDexterChart(GetTenMostWeakestPokemon(allPokemons));

            // Top Ten Fastest Legendary Pokemon 
            result.AddDexterChart(GetTenFastestLegendaryPokemon(allPokemons));

            return result;
        }

        private DexterChart GetTenFastestLegendaryPokemon(List<Pokemon> allPokemons)
        {
            var groupedTypes = allPokemons
                .Where(p => p.Legendary)
                .OrderByDescending(p => p.speed)
                .Take(10)
                .ToList();

            return new DexterChart()
            {
                ChartId = "ten_fastest_legendary",
                ChartLabel = "This graph the 10 fastest legendary Pokemon we have so far.",
                ChartTitle = "10 Fastest Legendary Pokemons",
                ChartType = TypeOfChart.BarChart,
                XAxisValues = groupedTypes.Select(g => g.name).ToList(),
                XLabel = "Pokemon Type",
                YAxisValues = groupedTypes.Select(g => g.speed).ToList(),
                YLabel = "Pokemon Count"
            };
        }

        private DexterChart GetTenMostWeakestPokemon(List<Pokemon> allPokemons)
        {
            // To get the pokemons with most x2 weaknesses,
            // we add all values of against_ columns
            // and sort by descending
            var sortedPokemons = allPokemons.Select(p =>
                new
                {
                    Pokemon = p,
                    SumStats = p.against_bug + p.against_dark + p.against_dragon + p.against_electric + p.against_fairy + p.against_fight + p.against_fire + p.against_flying + p.against_ghost + p.against_grass + p.against_ground + p.against_ice + p.against_normal + p.against_poison + p.against_psychic + p.against_rock + p.against_steel + p.against_water,
                })
                .OrderByDescending(item => item.SumStats)
                .Take(10)
                .ToList();

            return new DexterChart()
            {
                ChartId = "most_weakest",
                ChartLabel = "This graph shows the 10 most weakest pokemon determined by number of total x2 aggregate weaknesses.",
                ChartTitle = "Ten Most Weakest Pokemon Based on x2 Weaknesses",
                ChartType = TypeOfChart.PieChart,
                Is3D = true,
                XAxisValues = sortedPokemons.Select(g => g.Pokemon.name).ToList(),
                YAxisValues = sortedPokemons.Select(g => Convert.ToInt32(g.SumStats)).ToList(), // Can safely cast to int as all numbers being added are even whole numbers of 2 so no .5 decimals in this linq query
            };
        }

        public DexterChart GetTypePercentDistribution(List<Pokemon> allPokemons)
        {
            var groupedTypes = allPokemons
                .Select(p => p.type1)
                .GroupBy(p => p)
                .ToList();

            return new DexterChart()
            {
                ChartId = "type_distribution",
                ChartLabel = "This graph shows total distribution of pokemon by type across pokemon generations and their count.",
                ChartTitle = "Pokemon Distribution by Primary Type",
                ChartType = TypeOfChart.PieChart,
                XAxisValues = groupedTypes.Select(g => g.Key).ToList(),
                XLabel = "Pokemon Type",
                YAxisValues = groupedTypes.Select(g => g.Count()).ToList(),
                YLabel = "Pokemon Count"
            };
        }
    }
}
