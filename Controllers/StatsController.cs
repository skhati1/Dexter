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

            result.AddDexterChart(GetTypePercentDistribution(allPokemons));

            return result;
        }

        public DexterChart GetTypePercentDistribution(List<Pokemon> allPokemons)
        {
            var groupedTypes = allPokemons.Select(p => p.type1).GroupBy(p => p).ToList();
            return new DexterChart()
            {
                ChartId = "type_distribution",
                ChartLabel = "This graph shows total distribution of pokemon by type across pokemon generations and their count",
                ChartTitle = "Pokemon Distribution by Type",
                ChartType = "PieChart",
                XAxisValues = groupedTypes.Select(g => g.Key).ToList(),
                XLabel = "Pokemon Type",
                YAxisValues = groupedTypes.Select(g => g.Count()).ToList(),
                YLabel = "Pokemon Count"
            };
        }
    }
}
