using System;
using StackImplementation_November.Models.BlackJack;

namespace StackImplementation_November.Interfaces.BlackJack;

public interface IBlackJackService
{
    void AddPlayer(Player player);

    void RemovePlayer(Player player);

    void RunGame();

    int PlayerCount{get;}
}
