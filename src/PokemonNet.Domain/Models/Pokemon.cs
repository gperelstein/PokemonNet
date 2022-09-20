using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Models;

public class Pokemon
{
    public PokemonSpecies Species { get; set; }
    public bool Fainted { get; set; }
    public int Level { get; set; }
    public StatusCondition StatusCondition { get; set; }
    public int HitPoints { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    public List<Move> Moves { get; set; }

    public Pokemon(PokemonSpecies species, List<Move> moves)
    {
        Species = species;
        Fainted = false;
        StatusCondition = StatusCondition.Normal;
        HitPoints = species.HitPoints;
        Attack = species.Attack;
        Defense = species.Defense;
        SpecialAttack = species.SpecialAttack;
        SpecialDefense = species.SpecialDefense;
        Speed = species.Speed;
        Moves = moves;
    }
}
