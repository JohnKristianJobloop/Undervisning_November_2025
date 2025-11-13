using System;
using StackImplementation_November.Models.PlayingCard;

namespace StackImplementation_November.Models.BlackJack;

public class Player(string name, List<Card>? cards = null)
{
    public string Name {get;set;} = name;

    public List<Card> Cards {get;set;} = cards ?? [];

    public int CurrentHandValue => Cards.Aggregate(0, (current, card) =>
        current += card.Value switch
        {
            Enums.Value.King or Enums.Value.Queen or Enums.Value.Jack => 10,
            Enums.Value.Ace => current > 10 ? 1 : 11,
            _ => (int)card.Value
        }
    );

    public bool IsBust {get;set;} = false;

    public bool IsForfeit {get;set;} = false;

    public bool IsStanding {get;set;} = false;
}
