using System;
using System.ComponentModel.DataAnnotations;

namespace StackImplementation_November.Models.PlayingCard;

public class DeckEntity
{
    [Key]
    public int Id{get;init;}
    public ICollection<CardEntity> Cards {get;set;} = [];
}
