namespace Yathzee.Domain.Services;

/// <summary>
/// Interface for rolling dice in the Yahtzee game.
/// </summary>
public interface IDiceRoller
{
    /// <summary>
    /// Rolls a die and returns a random value between 1 and 6.
    /// </summary>
    /// <returns>The rolled value.</returns>
    int Roll();
}
