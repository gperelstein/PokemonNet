using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.BattleEvents;

public interface IBattleEvent
{
    void RunBattleEvent(Battle battle);
}
