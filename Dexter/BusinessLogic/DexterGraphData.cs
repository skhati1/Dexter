using Dexter.Models;

namespace Dexter.BusinessLogic
{
    public class DexterGraphData
    {
        private readonly DexterDbContext _context;

        public DexterGraphData(DexterDbContext context) {
            _context = context;
        }
        public DexterChart GetTenFastestLegendaryPokemon()
        {
            var groupedTypes = _context.Pokemons
                .Where(p => p.is_legendary == 1)
                .OrderByDescending(p => p.Speed)
                .Take(10)
                .ToList();

            return new DexterChart()
            {
                ChartId = "ten_fastest_legendary",
                ChartLabel = "This graph the 10 fastest legendary Pokemon we have so far.",
                ChartTitle = "10 Fastest Legendary Pokemons",
                ChartType = TypeOfChart.BarChart,
                XAxisValues = groupedTypes.Select(g => g.Name).ToList(),
                XLabel = "Pokemon Type",
                YAxisValues = groupedTypes.Select(g => g.Speed).ToList(),
                YLabel = "Speed Points",
                Width = 900,
                Height = 500,
            };
        }

        public DexterChart GetWeakestPokemonByType()
        {
            // To get the pokemons with most x2 weaknesses,
            // we add all values of against_ columns
            // and sort by descending
            var sortedPokemons = _context.Pokemons
                .AsEnumerable()
                .GroupBy(p => p.X2AndX4WeaknessCount)
                .OrderByDescending(item => item.Key)
                .Take(5)
                .ToList();

            return new DexterChart()
            {
                ChartId = "most_weakest",
                ChartLabel = "This graph shows the groups of most weakest pokemon determined by number of total x2 ad x4 aggregate weaknesses.",
                ChartTitle = "Groups of Most Weakest Pokemon Based on x2 and x4 Weaknesses",
                ChartType = TypeOfChart.BarChart,
                Is3D = true,
                XAxisValues = sortedPokemons.Select(p => String.Join(", ", p.Select(p => p.Name))).ToList(),
                YAxisValues = sortedPokemons.Select(p => p.Key).ToList(), // Can safely cast to int as all numbers being added are even whole numbers of 2 so no .5 decimals in this linq query
                Width = 1100,
                Height = 500,
            };
        }

        public DexterChart GetTypePercentDistribution()
        {
            var groupedTypes = _context.Pokemons
                .Select(p => p.Type1)
                .AsEnumerable()
                .GroupBy(p => p)
                .AsEnumerable();

            return new DexterChart()
            {
                ChartId = "type_distribution",
                ChartLabel = "This graph shows total distribution of pokemon by type across pokemon generations and their count.",
                ChartTitle = "Pokemon Distribution by Primary Type",
                ChartType = TypeOfChart.PieChart,
                XAxisValues = groupedTypes.Select(g => g.Key).ToList(),
                XLabel = "Pokemon Type",
                YAxisValues = groupedTypes.Select(g => g.Count()).ToList(),
                YLabel = "Pokemon Count",
                Width = 900,
                Height = 800,
            };
        }
    }
}
