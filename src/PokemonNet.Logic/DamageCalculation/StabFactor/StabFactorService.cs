using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.DamageCalculation.StabFactor;

public class StabFactorService : IStabFactorService
{
    public float GetStabFactor(Pokemon attackingPokemon, MoveBase move)
    {
        if (MoveHasStab(attackingPokemon, move))
        {
            return 1.5f;
        }

        return 1;
    }

    private static bool MoveHasStab(Pokemon attackingPokemon, MoveBase move)
    {
        return attackingPokemon.Species.TypeOne == move.Type || attackingPokemon.Species.TypeTwo == move.Type;
    }
}
