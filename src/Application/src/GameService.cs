namespace Yathzee.Application;

/// <summary>
/// Service for managing game operations in Yahtzee.
/// </summary>
public sealed class GameService
{
    /// <summary>
    /// Rolls five dice and returns their values.
    /// </summary>
    /// <returns>A collection of integers representing the rolled dice values.</returns>
    public ICollection<int> RollDice()
    {
        var random = new Random();
        var rolledDice = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            rolledDice.Add(random.Next(1, 7));
        }

        return rolledDice;
    }
}
