using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Logic.DamageCalculation.WeatherFactor;

internal class WeatherFactorService : IWeatherFactorService
{
    public float GetWeatherFactor(MoveBase move, Weather weather)
    {
        if (IsBeneficialWeather(move, weather))
        {
            return 1.5f;
        }

        if (IsPrejudicialWeather(move, weather))
        {
            return 0.5f;
        }

        return 1;
    }

    private static bool IsBeneficialWeather(MoveBase move, Weather weather)
    {
        return (weather == Weather.Rain && move.Type == PokemonType.Water) ||
            (weather == Weather.Sunny && move.Type == PokemonType.Fire);
    }

    private static bool IsPrejudicialWeather(MoveBase move, Weather weather)
    {
        return (weather == Weather.Rain && move.Type == PokemonType.Fire) ||
            (weather == Weather.Sunny && move.Type == PokemonType.Water);
    }
}
