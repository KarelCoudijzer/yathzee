using Yathzee.Domain.Services;

namespace Yathzee.Domain;

/// <summary>
/// Represents a single die in the Yahtzee game.
/// </summary>
public sealed record Dice
{
    private const int DefaultDieValue = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Dice"/> class with a default value of 1.
    /// </summary>
    public Dice()
        : this(DefaultDieValue)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Dice"/> class with a specified value. 
    /// </summary>
    /// <param name="value">The value, must be between 1 and 6, inclusive.</param>
    public Dice(int value)
    {
        if (value < 1 || value > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Dice value must be between 1 and 6.");
        }

        Value = value;
    }

    /// <summary>
    /// Gets the current value of the die.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Rolls the die and returns a new instance of <see cref="Dice"/> with a random value between 1 and 6.
    /// </summary>
    /// <returns>The rolled dice.</returns>
    public Dice Roll(IDiceRoller roller)
    {
        ArgumentNullException.ThrowIfNull(roller, nameof(roller));

        return new Dice(roller.Roll());
    }
}
