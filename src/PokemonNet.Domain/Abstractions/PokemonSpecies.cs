using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Abstractions;

public abstract class PokemonSpecies
{
    public string Name => GetType().Name;
    public abstract int HitPoints { get; }
    public abstract int Attack { get; }
    public abstract int Defense { get; }
    public abstract int SpecialAttack { get; }
    public abstract int SpecialDefense { get; }
    public abstract int Speed { get; }
    public abstract PokemonType TypeOne { get; }
    public abstract PokemonType? TypeTwo { get; }
}
