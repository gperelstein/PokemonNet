using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.DamageCalculation.StabFactor;

public interface IStabFactorService
{
    float GetStabFactor(Pokemon attackingPokemon, MoveBase move);
}
