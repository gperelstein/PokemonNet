using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.BattleEvents;

public class SelectAttack : IBattleEvent
{
    public int SidePosition { get; set; }
    public int SelectedMovePosition { get; set; }

    public SelectAttack(int sidePosition, int selectedMovePosition)
    {
        SidePosition = sidePosition;
        SelectedMovePosition = selectedMovePosition;
    }

    public void RunBattleEvent(Battle battle)
    {
        battle.Sides.ElementAt(SidePosition).SelectedMovePosition = SelectedMovePosition;
    }
}
