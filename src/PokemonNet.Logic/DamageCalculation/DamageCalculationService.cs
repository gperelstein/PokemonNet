using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;
using PokemonNet.Domain.Models;
using PokemonNet.Logic.DamageCalculation.RandomFactor;
using PokemonNet.Logic.DamageCalculation.StabFactor;
using PokemonNet.Logic.DamageCalculation.WeatherFactor;

namespace PokemonNet.Logic.DamageCalculation;

public class DamageCalculationService : IDamageCalculationService
{
    private readonly IStabFactorService _stabFactorService;
    private readonly IWeatherFactorService _weatherFactorService;
    private readonly IRandomFactorService _randomFactorService;

    public DamageCalculationService(IStabFactorService stabFactorService,
        IWeatherFactorService weatherFactorService,
        IRandomFactorService randomFactorService)
    {
        _stabFactorService = stabFactorService;
        _weatherFactorService = weatherFactorService;
        _randomFactorService = randomFactorService;
    }

    public int CalculateDamage(Pokemon attackingPokemon, Pokemon defendingPokemon, Move move, bool isCriticalHit, Weather weather)
    {
        if (move.MoveBase.Category == MoveCategory.Status)
        {
            return 0;
        }

        var critical = isCriticalHit ? 1.5 : 1;

        var attackDefenseRelation = GetAttackDefenseRelation(attackingPokemon, defendingPokemon, move.MoveBase);

        var targets = 1;

        var pb = 1;

        var weatherFactor = _weatherFactorService.GetWeatherFactor(move.MoveBase, weather);

        var random = _randomFactorService.GetRandomFactor();

        var stab = _stabFactorService.GetStabFactor(attackingPokemon, move.MoveBase);

        var burn = GetBurnFactor(attackingPokemon, move.MoveBase);

        var other = 1;

        var baseDamage = (((2 * (float)attackingPokemon.Level / 5) + 2) * (float)move.MoveBase.Power * (float)attackDefenseRelation / 50) + 2;

        var damage = baseDamage * targets * pb * weatherFactor * critical * random * stab * burn * other;

        return (int)damage;
    }

    private static float GetAttackDefenseRelation(Pokemon attackingPokemon, Pokemon defendingPokemon, MoveBase move)
    {
        if (move.Category == MoveCategory.Physical)
        {
            return (float)attackingPokemon.Attack / (float)defendingPokemon.Defense;
        }

        return (float)attackingPokemon.SpecialAttack / (float)defendingPokemon.SpecialDefense;
    }

    private static float GetBurnFactor(Pokemon attackingPokemon, MoveBase move)
    {
        if (attackingPokemon.StatusCondition == StatusCondition.Burn && move.Category == MoveCategory.Physical)
        {
            return 0.5f;
        }

        return 1;
    }
}
