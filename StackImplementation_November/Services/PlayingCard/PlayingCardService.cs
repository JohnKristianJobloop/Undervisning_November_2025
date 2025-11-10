using System;
using StackImplementation_November.Enums;
using StackImplementation_November.Models;
using StackImplementation_November.Models.PlayingCard;

namespace StackImplementation_November.Services.PlayingCard;

public class PlayingCardService<T> where T : Card
{
    private KhStack<T> _deck = [];

    public IEnumerable<T> Draw(int amount)
    {
        int incrementor = 0;

        while (incrementor < amount)
        {
            yield return _deck.Pop();
        }
    }

    public PlayingCardService(bool includeJoker = false)
    {
        var deck = new List<T>();

        foreach (var suit in Enum.GetValues<Suits>())
        {
            foreach (var val in Enum.GetValues<Value>())
            {
                if (!includeJoker && val is Value.Joker) continue;
                deck.Add(new Card
                {
                    Suit = suit,
                    Color = GetColorForPlayingCard(suit),
                    Value = val
                } as T ?? default!);
            }
        }
        foreach (var card in deck.OrderBy(c => Random.Shared.Next()))
        {
            _deck.Push(card);
        } 
        
    }
    private Color GetColorForPlayingCard(Suits suit)
    {
        if (suit == Suits.Heart || suit == Suits.Diamond) return Color.Red;
        return Color.Black; 
    }


}
