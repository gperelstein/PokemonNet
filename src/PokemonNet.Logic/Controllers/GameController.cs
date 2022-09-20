using PokemonNet.Domain.Models;
using PokemonNet.Logic.BattleEvents;
using PokemonNet.Logic.Games;

namespace PokemonNet.Logic.Controllers;

public class GameController
{
    public void SelectAttack(Game game, int sidePosition, int moveSelectedPosition)
    {
        var selectAttackEvent = new SelectAttack(sidePosition, moveSelectedPosition);

        game.BattleEventsOfRound.Add(selectAttackEvent);
    }

    public void SwitchPokemon(Game game, int sidePosition, int newActivePokemonPosition)
    {
        var switchPokemonEvent = new SwitchPokemon(sidePosition, newActivePokemonPosition);

        game.BattleEventsOfRound.Add(switchPokemonEvent);
    }

    public void ExecuteRound(Game game)
    {
        var battle = game.Battle;

        foreach (var battleEvent in game.BattleEventsOfRound)
        {
            battleEvent.RunBattleEvent(battle);
        }

        ExecuteAttacks(battle);

        EndRound(game);
    }

    private void ExecuteAttacks(Battle battle)
    {
        battle.AttackingPokemonSide = battle.Sides.OrderByDescending(x => x.ActivePokemon.Speed).First();
        battle.DefendingPokemonSide = battle.Sides.OrderBy(x => x.ActivePokemon.Speed).First();

        if (battle.AttackingPokemonSide.SelectedMovePosition != null)
        {
            battle.AttackingPokemonSide.ActivePokemon.Moves.ElementAt(battle.AttackingPokemonSide.SelectedMovePosition.Value).OnHit(battle);
        }

        (battle.DefendingPokemonSide, battle.AttackingPokemonSide) = (battle.AttackingPokemonSide, battle.DefendingPokemonSide);

        if (battle.AttackingPokemonSide.SelectedMovePosition != null)
        {
            battle.AttackingPokemonSide.ActivePokemon.Moves.ElementAt(battle.AttackingPokemonSide.SelectedMovePosition.Value).OnHit(battle);
        }
    }

    private void EndRound(Game game)
    {
        game.BattleEventsOfRound.Clear();
    }
}
