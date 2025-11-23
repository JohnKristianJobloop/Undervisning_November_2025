using System;
using System.IO.Compression;
using StackImplementation_November.Enums.BlackJack;
using StackImplementation_November.Extentions;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

namespace StackImplementation_November.Services.BlackJack;

public class BlackJackGame(int maxPlayerCount = 4) : IBlackJackGame
{
    public BlackJackGame(PlayingCardService<Card> cards, int maxPlayerCount = 4) : this(maxPlayerCount)
    {
        _playingCards = cards;
    }
    private List<Player> _players = [];

    private PlayingCardService<Card> _playingCards = new();

    private int _currentPlayer = 0;

    public int PlayerCount => _players.Count;

    public Card? Draw(int amount) => _playingCards.Draw(1).FirstOrDefault();

    public void AddPlayer(Player player)
    {
        if (PlayerCount >= maxPlayerCount)
        {
            throw new ArgumentException("Cannot add more players to the game.");
        }
        else
        {
            _players.Add(player);
        }
    }

    public bool RemovePlayer(Player player) => _players.Remove(player);

    public Player GetCurrentPlayer() => _players[_currentPlayer];

}
