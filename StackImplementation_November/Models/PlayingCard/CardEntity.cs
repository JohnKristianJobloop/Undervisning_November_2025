
using System.ComponentModel.DataAnnotations;
using StackImplementation_November.Enums;

namespace StackImplementation_November.Models.PlayingCard;

public class CardEntity
{
    [Key]
    public int Id {get;init;}
    public Color Color{get;init;}
    public Suits Suit {get;init;}
    public Value Value {get;init;}
    public ICollection<DeckEntity> Decks {get;set;} = [];
}
