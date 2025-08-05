using Yathzee.Domain.Services;

namespace Yathzee.Domain.Tests;

public class DiceTests
{
    [Fact]
    public void Dice_WithoutValue_SetsDefaultValue()
    {
        // Arrange & Act
        var dice = new Dice();

        // Assert
        Assert.Equal(1, dice.Value);
    }

    [Fact]
    public void Dice_WithValidValue_SetsValue()
    {
        // Arrange & Act
        var dice = new Dice(3);

        // Assert
        Assert.Equal(3, dice.Value);
    }

    [Fact]
    public void Dice_WithInvalidValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Dice(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Dice(7));
    }

    [Fact]
    public void Roll_WithNullRoller_ThrowsArgumentNullException()
    {
        // Arrange
        var dice = new Dice();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => dice.Roll(null!));
    }

    [Fact]
    public void Roll_WithValidRoller_ShouldReturnNewDice()
    {
        // Arrange
        var dice = new Dice();
        var roller = new FakeDiceRoller(4);

        // Act
        var rolledDice = dice.Roll(roller);

        // Assert
        Assert.NotSame(dice, rolledDice);
        Assert.Equal(4, rolledDice.Value);
    }

    [Fact]
    public void Roll_WithValidRoller_ShouldNotMutateOriginalDice()
    {
        // Arrange
        var dice = new Dice(2);
        var roller = new FakeDiceRoller(5);

        // Act
        var rolledDice = dice.Roll(roller);

        // Assert
        Assert.Equal(2, dice.Value);
        Assert.Equal(5, rolledDice.Value);
    }

    private sealed class FakeDiceRoller : IDiceRoller
    {
        private readonly int _fixedValue;

        public FakeDiceRoller(int fixedValue)
        {
            _fixedValue = fixedValue;
        }

        public int Roll()
        {
            return _fixedValue;
        }
    }
}
