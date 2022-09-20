using Moq;
using PokemonNet.Domain.Abstractions;
using PokemonNet.Domain.Data.Species;
using PokemonNet.Domain.Enums;
using PokemonNet.Domain.Models;
using PokemonNet.Logic.Controllers;
using PokemonNet.Logic.DamageCalculation;
using PokemonNet.Logic.Games;
using PokemonNet.Logic.Moves;
using System.Collections.Generic;
using Xunit;

namespace PokemonNet.Logic.Tests.Controllers;

public class GameControllerTests
{
    [Fact]
    public void CreateBattle_ShouldCreateBattle_WhenSucceeded()
    {
        var serviceCalulationService = new Mock<IDamageCalculationService>();
        serviceCalulationService.SetupSequence(x => x.CalculateDamage(It.IsAny<Pokemon>(),
            It.IsAny<Pokemon>(),
            It.IsAny<Move>(),
            It.IsAny<bool>(),
            It.IsAny<Weather>()))
            .Returns(20)
            .Returns(40);

        var bulbasaurSpecie = new Bulbasaur();
        var bulbasaur = new Pokemon(bulbasaurSpecie, new List<Move> { new Tackle(serviceCalulationService.Object) });
        var squirtleSpecie = new Squirtle();
        var squirtle = new Pokemon(squirtleSpecie, new List<Move> { new Tackle(serviceCalulationService.Object) });
        var side1 = new Side(new List<Pokemon> { bulbasaur }, 0);
        var side2 = new Side(new List<Pokemon> { squirtle }, 0);
        var sides = new List<Side> { side1, side2 };
        var battle = new Battle(sides);
        var game = new Game(battle);
        var gameController = new GameController();
        gameController.SelectAttack(game, 0, 0);
        gameController.SelectAttack(game, 1, 0);

        gameController.ExecuteRound(game);

        Assert.Equal(squirtleSpecie.HitPoints - 20, squirtle.HitPoints);
        Assert.Equal(bulbasaurSpecie.HitPoints - 40, bulbasaur.HitPoints);
    }
}
