using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dexter.Models;

namespace Dexter
{
    public class PokemonController : Controller
    {
        private readonly DexterDbContext _context;

        public PokemonController(DexterDbContext context)
        {
            _context = context;
        }

        // GET: Pokemon
        public async Task<IActionResult> Index()
        {
            // Only show user created pokemons for simplicity
            return View(await _context.Pokemons.Where(p => p.PokedexNumber > 801).ToListAsync());
        }

        // GET: Pokemon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokemon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("against_bug,against_dark,against_dragon,against_electric,against_fairy,against_fight,against_fire,against_flying,against_ghost,against_grass,against_ground,against_ice,against_normal,against_poison,against_psychic,against_rock,against_steel,against_water,Attack,base_egg_steps,base_happiness,base_total,CaptureRate,classfication,Defense,experience_growth,height_m,HP,japanese_name,Name,percentage_male,PokedexNumber,SpecialAttack,SpecialDefense,Speed,Type1,type2,weight_kg,generation,is_legendary")] Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        // GET: Pokemon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pokemons == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        // POST: Pokemon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("against_bug,against_dark,against_dragon,against_electric,against_fairy,against_fight,against_fire,against_flying,against_ghost,against_grass,against_ground,against_ice,against_normal,against_poison,against_psychic,against_rock,against_steel,against_water,Attack,base_egg_steps,base_happiness,base_total,CaptureRate,classfication,Defense,experience_growth,height_m,HP,japanese_name,Name,percentage_male,PokedexNumber,SpecialAttack,SpecialDefense,Speed,Type1,type2,weight_kg,generation,is_legendary")] Pokemon pokemon)
        {
            if (id != pokemon.PokedexNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.PokedexNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        // GET: Pokemon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pokemons == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.PokedexNumber == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pokemons == null)
            {
                return Problem("Entity set 'DexterDbContext.Pokemons'  is null.");
            }
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokedexNumber == id);
        }
    }
}
