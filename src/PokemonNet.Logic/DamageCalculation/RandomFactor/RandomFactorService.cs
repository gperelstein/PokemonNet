namespace PokemonNet.Logic.DamageCalculation.RandomFactor;

public class RandomFactorService : IRandomFactorService
{
    public float GetRandomFactor()
    {
        var randomGenerator = new Random();

        var randomFactor = (float)randomGenerator.Next(85, 100) / 100;

        return randomFactor;
    }
}
