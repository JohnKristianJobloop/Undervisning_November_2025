
using StackImplementation_November.Enums;

namespace StackImplementation_November.Models.PlayingCard;

public class Card
{
    public Color Color { get; set; }
    public Suits Suit { get; set; }

    public Value Value { get; set; }

    public string Name { get => $"{Color.GetName(Color)} {Value.GetName(Value)} of {Suits.GetName(Suit)}"; }
}
