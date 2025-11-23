using System;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Models.PlayingCard;

namespace StackImplementation_November.Interfaces.BlackJack;

public interface IBlackJackGame
{
    void AddPlayer(Player player);

    bool RemovePlayer(Player player);


    Card? Draw(int amount = 1);

    int PlayerCount{get;}
}
