using System;
using System.IO.Compression;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

namespace StackImplementation_November.Services.BlackJack;

public class BlackJackService : IBlackJackService
{
    private List<Player> _players = [];

    private PlayingCardService<Card> _playingCards = new();

    private int _currentPlayer = 0;

    public int PlayerCount => _players.Count;

    public void AddPlayer(Player player) => _players.Add(player);
    public void RemovePlayer(Player player) => _players.Remove(player);

    public void RunGame()
    {
        if (PlayerCount <= 0) throw new ArgumentException("Can't start the game with no players.");
        throw new NotImplementedException();
    }
}
