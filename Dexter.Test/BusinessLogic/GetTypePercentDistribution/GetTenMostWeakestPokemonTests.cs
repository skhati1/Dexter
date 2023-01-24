using Dexter.BusinessLogic;

namespace Dexter.Test.BusinessLogic
{
    [TestClass]
    public class GetTypePercentDistribution
    {
        private DexterGraphData? _data;
        private DexterDbContext _context;
        public GetTypePercentDistribution()
        {
            _context = new DexterMockDatabase().context;
        }
        [TestMethod]
        public void CheckDistributionGroupingReturnedIsCorrect()
        {
            var _context = new DexterMockDatabase().context;
            var _data = new DexterGraphData(_context);
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 1,
                Name = "Bulbasaur",
                Type1 = "grass",
            });
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 2,
                Name = "Ivysaur",
                Type1 = "grass",
            });
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 26,
                Name = "Pikachu",
                Type1 = "electric",
            });
            _context.SaveChanges();

            _data = new DexterGraphData(_context);
            var result = _data.GetTypePercentDistribution();

            var expectedXValues = new List<string>() { "grass", "electric" };
            var expectedYValues = new List<int>() { 2, 1 };

            CollectionAssert.AreEqual(result.XAxisValues, expectedXValues);
            CollectionAssert.AreEqual(result.YAxisValues, expectedYValues);
        }
    }
}