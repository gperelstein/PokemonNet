namespace PokemonNet.Domain.Models;

public class Side
{
    public Pokemon ActivePokemon { get; set; }
    public List<Pokemon> BenchPokemon => Pokemon.Where(x => !x.Fainted && x != ActivePokemon).ToList();
    public List<Pokemon> FaintedPokemon => Pokemon.Where(x => x.Fainted).ToList();
    public List<Pokemon> Pokemon { get; set; } = new();
    public int? SelectedMovePosition { get; set; }

    public Side(List<Pokemon> pokemon, int activePokemonPosition)
    {
        Pokemon = pokemon;
        ActivePokemon = Pokemon.ElementAt(activePokemonPosition);
    }
}
