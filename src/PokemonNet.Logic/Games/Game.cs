using PokemonNet.Domain.Models;
using PokemonNet.Logic.BattleEvents;
using PokemonNet.Logic.Games.Enums;

namespace PokemonNet.Logic.Games;

public class Game
{
    public Battle Battle { get; }
    public List<IBattleEvent> BattleEventsOfRound { get; }
    public GameState State { get; set; }

    public Game(Battle battle)
    {
        Battle = battle;
        BattleEventsOfRound = new();
        State = GameState.WaitingForPlayerAction;
    }
}
