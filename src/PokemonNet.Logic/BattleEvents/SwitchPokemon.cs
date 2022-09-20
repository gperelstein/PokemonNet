using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.BattleEvents;

public class SwitchPokemon : IBattleEvent
{
    public int SidePosition { get; set; }
    public int NewActivePokemonPosition { get; set; }

    public SwitchPokemon(int sidePosition, int newActivePokemonPosition)
    {
        SidePosition = sidePosition;
        NewActivePokemonPosition = newActivePokemonPosition;
    }

    public void RunBattleEvent(Battle battle)
    {
        var side = GetSide(battle);

        side.ActivePokemon = GetNewActivePokemon(battle);

        side.SelectedMovePosition = null;
    }

    private Side GetSide(Battle battle)
    {
        return battle
            .Sides
            .ElementAt(SidePosition);
    }

    private Pokemon GetNewActivePokemon(Battle battle)
    {
        return battle
            .Sides
            .ElementAt(SidePosition)
            .Pokemon
            .ElementAt(NewActivePokemonPosition);
    }
}
