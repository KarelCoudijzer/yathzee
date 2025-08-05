namespace Yahtzee.Application.Tests;

using Yathzee.Application;

public sealed class GameServiceTests
{
    [Fact]
    public void GameService_ShouldInitialize_WhenCreated()
    {
        // Arrange & Act
        var gameService = new GameService();

        // Assert
        Assert.NotNull(gameService);
    }

    [Fact]
    public void RollDice_ShouldRollAllDice_WhenCalled()
    {
        // Arrange
        var gameService = new GameService();

        // Act
        var rolledDice = gameService.RollDice();

        // Assert
        Assert.NotNull(rolledDice);
        Assert.Equal(5, rolledDice.Count);
        Assert.All(rolledDice, die => Assert.True(die >= 1 && die <= 6));
    }
}