using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Data.MovesBase;
using PokemonNet.Domain.Models;
using PokemonNet.Logic.DamageCalculation;

namespace PokemonNet.Logic.Moves;

public class Tackle : Move
{
    public override MoveBase MoveBase => new TackleBase();

    private readonly IDamageCalculationService _damageCalculationService;

    public Tackle(IDamageCalculationService damageCalculationService)
    {
        _damageCalculationService = damageCalculationService;
    }

    public override void OnHit(Battle battle)
    {
        /*var damage = DamageCalculationCalculator
            .CalculateDamage(battle.AttackingPokemonSide.ActivePokemon, battle.DefendingPokemonSide.ActivePokemon, this, false, battle.Weather);*/

        var damage = _damageCalculationService.CalculateDamage(battle.AttackingPokemonSide.ActivePokemon,
            battle.DefendingPokemonSide.ActivePokemon,
            this,
            false,
            battle.Weather);

        battle.DefendingPokemonSide.ActivePokemon.HitPoints -= damage;
    }
}
