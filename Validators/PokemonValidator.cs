using Dexter.Models;
using FluentValidation;

namespace Dexter.Validators
{
    public class PokemonValidator: AbstractValidator<Pokemon>
    {
        public PokemonValidator() 
        {
            // All Pokemon should always have a pokedex number
            RuleFor(p => p.PokedexNumber).NotNull();

            // Can't have pokemon that doesn't have at least one type
            RuleFor(p => p.Type1).NotNull();

            // All Pokemon's base stats have to be a positive number
            RuleFor(p => p.HP).GreaterThan(0);
            RuleFor(p => p.Attack).GreaterThan(0);
            RuleFor(p => p.SpecialAttack).GreaterThan(0);
            RuleFor(p => p.Defense).GreaterThan(0);
            RuleFor(p => p.SpecialDefense).GreaterThan(0);
            RuleFor(p => p.Speed).GreaterThan(0);

            // All Pokemons have a capture rate ranging between 0 and 255
            RuleFor(p => p.CaptureRate).GreaterThan(0);
            RuleFor(p => p.CaptureRate).LessThanOrEqualTo(255);

            // If a pokemon is legendary, it MUST belong to a generation
            When(p => p.is_legendary == 1, () =>
            {
                RuleFor(p => p.generation)
                    .NotNull()
                    .WithMessage("Legendary Pokemon must belong to a Generation")
                    .GreaterThan(0)
                    .WithMessage("Generation must be at least 1 - Johto")
                    .LessThanOrEqualTo(7)
                    .WithMessage("Cannot have generation > 7 as there are only 7 generations");
            });

        }
    }
}
