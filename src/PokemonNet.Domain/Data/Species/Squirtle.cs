using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Data.Species;

public class Squirtle : PokemonSpecies
{
    public override int HitPoints => 44;
    public override int Attack => 48;
    public override int Defense => 65;
    public override int SpecialAttack => 50;
    public override int SpecialDefense => 64;
    public override int Speed => 43;
    public override PokemonType TypeOne => PokemonType.Water;
    public override PokemonType? TypeTwo => null;
}
