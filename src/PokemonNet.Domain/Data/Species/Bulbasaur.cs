using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Data.Species;

public class Bulbasaur : PokemonSpecies
{
    public override int HitPoints => 45;
    public override int Attack => 49;
    public override int Defense => 49;
    public override int SpecialAttack => 65;
    public override int SpecialDefense => 65;
    public override int Speed => 45;
    public override PokemonType TypeOne => PokemonType.Grass;
    public override PokemonType? TypeTwo => PokemonType.Poison;
}
