using Dexter.BusinessLogic;

namespace Dexter.Test.BusinessLogic
{
    [TestClass]
    public class GetTestFastestLegendaryPokemonTests
    {
        private DexterGraphData? _data;
        private DexterDbContext _context;
        public GetTestFastestLegendaryPokemonTests()
        {
            _context = new DexterMockDatabase().context;
        }
        [TestMethod]
        public void CheckLessThan10LegendariesReturnDescending()
        {
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 1,
                Name = "DummyOne",
                Type1 = "grass",
                Speed = 1,
                is_legendary = 1
            });
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 2,
                Name = "DummyTwo",
                Type1 = "water",
                Speed = 2,
                is_legendary = 1
            });
            _context.SaveChanges();
            var expectedYValues = new List<int>() { 2, 1 };
            var expectedXValues = new List<string>() { "DummyTwo", "DummyOne" };

            _data = new DexterGraphData(_context);
            var result = _data.GetTenFastestLegendaryPokemon();

            CollectionAssert.AreEqual(result.XAxisValues, expectedXValues);
            CollectionAssert.AreEqual(result.YAxisValues, expectedYValues);
        }


        [TestMethod]
        public void CheckMoreThan10LegendariesReturnCorrectl()
        {
            for(int i = 1; i < 12; i++)
            {
                _context.Pokemons.Add(new Models.Pokemon()
                {
                    PokedexNumber = i,
                    Name = "Dummy" + i,
                    Type1 = "fire",
                    Speed = i,
                    is_legendary = 1
                });

            }
            _context.SaveChanges();
            var expectedYValues = new List<int>() { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            _data = new DexterGraphData(_context);
            var result = _data.GetTenFastestLegendaryPokemon();

            CollectionAssert.AreEqual(result.YAxisValues, expectedYValues);
        }


        [TestMethod]
        public void CheckNoLegendariesReturnsEmptyList()
        {
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 1,
                Name = "DummyOne",
                Type1 = "fire",
                Speed = 1,
                is_legendary = 0
            });
            _context.SaveChanges();

            _data = new DexterGraphData(_context);
            var result = _data.GetTenFastestLegendaryPokemon();

            Assert.IsTrue(result.XAxisValues.Count == 0);
        }
    }
}