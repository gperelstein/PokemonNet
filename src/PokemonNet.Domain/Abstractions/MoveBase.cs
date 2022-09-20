using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Abstractions;

public abstract class MoveBase
{
    public string Name => GetType().Name.Replace("Base", "");
    public abstract int Power { get; }
    public abstract int Accuracy { get; }
    public abstract int PowerPoints { get; }
    public abstract int MaxPowerPoints { get; }
    public abstract int Priority { get; }
    public abstract MoveCategory Category { get; }
    public abstract PokemonType Type { get; }
}
