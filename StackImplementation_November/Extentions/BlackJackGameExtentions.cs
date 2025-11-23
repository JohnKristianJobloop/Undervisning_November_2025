using System;
using StackImplementation_November.Enums.BlackJack;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Services.BlackJack;

namespace StackImplementation_November.Extentions;

public static class BlackJackGameExtentions
{
    public static Player HandleActionForCurrentPlayer(this BlackJackGame game, Operations ops)
    {
        var currentPlayer = game.GetCurrentPlayer();
        return currentPlayer.HandleInput(game, ops);
    }
}
