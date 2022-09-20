using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;
using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.DamageCalculation;

public interface IDamageCalculationService
{
    int CalculateDamage(Pokemon attackingPokemon, Pokemon defendingPokemon, Move move, bool isCriticalHit, Weather weather);
}
