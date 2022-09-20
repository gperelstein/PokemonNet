using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Logic.DamageCalculation.WeatherFactor;

public interface IWeatherFactorService
{
    float GetWeatherFactor(MoveBase move, Weather weather);
}
