using Yathzee.Domain;
using Yathzee.Domain.Services;

namespace Yathzee.Application;

/// <summary>
/// Service for managing game operations in Yahtzee.
/// </summary>
public sealed class GameService
{
    private readonly IDiceRoller _diceRoller;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameService"/> class.
    /// </summary>
    /// <param name="diceRoller">The service used for rolling dice.</param>
    public GameService(IDiceRoller diceRoller)
    {
        ArgumentNullException.ThrowIfNull(diceRoller, nameof(diceRoller));

        _diceRoller = diceRoller;
    }

    /// <summary>
    /// Rolls five dice and returns their values.
    /// </summary>
    /// <returns>A collection of integers representing the rolled dice values.</returns>
    public ICollection<Dice> RollDice()
    {
        var rolledDice = new List<Dice>();

        for (int i = 0; i < 5; i++)
        {
            rolledDice.Add(new Dice().Roll(_diceRoller));
        }

        return rolledDice;
    }
}
