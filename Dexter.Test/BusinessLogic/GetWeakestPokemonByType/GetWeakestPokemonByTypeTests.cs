using Dexter.BusinessLogic;
using Dexter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Dexter.Test.BusinessLogic
{
    [TestClass]
    public class GetWeakestPokemonByTypeTests
    {
        private DexterGraphData? _data;
        private DexterDbContext _context;
        public GetWeakestPokemonByTypeTests()
        {
            _context = new DexterMockDatabase().context;
        }
        [TestMethod]
        public void CheckLessThan10PokemonReturnsCorrectly()
        {
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 1,
                Name = "DummyOne",
                Type1 = "fire",
                against_fire = 2,
                Speed = 1,
                is_legendary = 1
            });
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 2,
                Name = "DummyTwo",
                Type1 = "water",
                against_bug = 4,
                Speed = 2,
                is_legendary = 1
            });
            _context.Pokemons.Add(new Models.Pokemon()
            {
                PokedexNumber = 3,
                Name = "DummyThree",
                Type1 = "grass",
                against_bug = 4,
                against_water = 4,
                Speed = 1,
                is_legendary = 1
            });
            _context.SaveChanges();
            var expectedYValues = new List<int>() { 2, 1 };
            var expectedXValues = new List<string>() { "DummyThree", "DummyOne, DummyTwo" };

            _data = new DexterGraphData(_context);
            var result = _data.GetWeakestPokemonByType();

            CollectionAssert.AreEqual(result.XAxisValues, expectedXValues);
            CollectionAssert.AreEqual(result.YAxisValues, expectedYValues);
        }


        [TestMethod]
        public void CheckMoreThan10PokemonsReturnsOnly10()
        {
            var input = new List<Pokemon>();
            for (int i = 1; i < 12; i++)
            {
                input.Add(new Models.Pokemon()
                {
                    PokedexNumber = i,
                    Name = "Dummy" + i,
                    Type1 = "grass",
                    against_bug = i % 3,
                    is_legendary = 1
                });
            }
            input[0].against_dark = 4;
            input[0].against_electric = 2; 
            _context.Pokemons.AddRange(input);
            _context.SaveChanges();
            var expectedYValues = new List<int>() { 2, 1, 0 };

            _data = new DexterGraphData(_context);
            var result = _data.GetWeakestPokemonByType();

            CollectionAssert.AreEqual(result.YAxisValues, expectedYValues);
        }
    }
}