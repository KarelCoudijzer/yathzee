namespace Yahtzee.Application.Tests;

using Yathzee.Application;
using Yathzee.Domain;
using Yathzee.Domain.Services;

public sealed class GameServiceTests
{

    private readonly DiceRollerSpy _diceRoller;

    public GameServiceTests()
    {
        _diceRoller = new DiceRollerSpy();
    }

    [Fact]
    public void GameService_NullDiceRoller_ThrowsArgumentNullException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentNullException>(() => new GameService(null!));
    }

    [Fact]
    public void GameService_ValidDiceRoller_WhenCreated()
    {
        // Arrange & Act
        var gameService = new GameService(_diceRoller);

        // Assert
        Assert.NotNull(gameService);
    }

    [Fact]
    public void RollDice_ShouldRollAllDice_WhenCalled()
    {
        // Arrange
        var gameService = new GameService(_diceRoller);

        // Act
        ICollection<Dice> rolledDice = gameService.RollDice();

        // Assert service calls
        Assert.Equal(5, _diceRoller.RollCallCount);

        // Assert rolled dice
        Assert.NotNull(rolledDice);
        Assert.Equal(5, rolledDice.Count);
    }

    private sealed class DiceRollerSpy : IDiceRoller
    {
        public DiceRollerSpy()
        {
            RollCallCount = 0;
        }

        public int RollCallCount { get; private set; }

        public int Roll()
        {
            RollCallCount++;

            return 4;
        }
    }
}