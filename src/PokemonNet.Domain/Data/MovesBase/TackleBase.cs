using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Enums;

namespace PokemonNet.Domain.Data.MovesBase;

public class TackleBase : MoveBase
{
    public override int Power => 50;
    public override int Accuracy => 100;
    public override int PowerPoints => 35;
    public override int MaxPowerPoints => 56;
    public override int Priority => 0;
    public override MoveCategory Category => MoveCategory.Physical;
    public override PokemonType Type => PokemonType.Normal;
}
