using PokemonNet.Domain.Models;

namespace PokemonNet.Domain.Abstractions;

public abstract class Move
{
    public abstract MoveBase MoveBase { get; }

    public abstract void OnHit(Battle battle);
}
