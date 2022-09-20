using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Models;

public class Battle
{
    public Side AttackingPokemonSide { get; set; }
    public Side DefendingPokemonSide { get; set; }
    public List<Side> Sides { get; set; }
    public Weather Weather { get; set; }

    public Battle(List<Side> sides)
    {
        Sides = sides;
        AttackingPokemonSide = Sides.OrderByDescending(x => x.ActivePokemon.Speed).First();
        DefendingPokemonSide = Sides.OrderBy(x => x.ActivePokemon.Speed).First();
        Weather = Weather.Clear;
    }
}
