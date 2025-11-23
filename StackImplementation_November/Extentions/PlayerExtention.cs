using StackImplementation_November.Enums.BlackJack;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models.BlackJack;

namespace StackImplementation_November.Extentions;

public static class PlayerExtention
{
    public static Player CheckIfBust(this Player player)
    {
        if (player.GetHandScore() > 21)
        {
            player.IsBust = true;
        }
        return player;
    }

    public static Player DoubleDown(this Player player, IBlackJackGame service)
    {
        player.Hit(service);
        player.Stand();
        return player.CheckIfBust();
    }

    public static int GetHandScore(this Player player)
    {
        return player.CurrentHandValue;
    }

    public static Player Hit(this Player player, IBlackJackGame service)
    {
        if (player is Dealer dealer)
        {
            if (dealer.GetHandScore() >= 15) return dealer.Stand();
        }
        var card = service.Draw(1);
        if (card is null) player.Stand();
        else player.Cards.Add(card);
        return player.CheckIfBust();
    }

    public static Player Stand(this Player player)
    {
        player.IsStanding = true;
        return player;
    }
    public static Player Forfeit(this Player player)
    {
        player.IsForfeit = true;
        return player;
    }
    public static Player HandleInput(this Player player, IBlackJackGame service, Operations ops)
    {
        return ops switch
        {
            Operations.Hit => player.Hit(service),
            Operations.DoubleDown => player.DoubleDown(service),
            Operations.Stand => player.Stand(),
            Operations.Forfeit => player.Forfeit(),
            _ => throw new NotImplementedException()
        };
    }
}