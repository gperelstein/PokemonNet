using PokemonNet.Domain.Enums;
using PokemonNet.Domain.Models;

namespace PokemonNet.Logic.BattleEvents;

public class ChangeWeather : IBattleEvent
{
    public Weather NewWeather { get; set; }

    public ChangeWeather(Weather newWeather)
    {
        NewWeather = newWeather;
    }

    public void RunBattleEvent(Battle battle)
    {
        battle.Weather = NewWeather;
    }
}
