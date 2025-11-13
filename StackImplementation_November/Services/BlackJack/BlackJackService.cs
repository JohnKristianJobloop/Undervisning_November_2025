using System;
using System.IO.Compression;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models.BlackJack;

namespace StackImplementation_November.Services.BlackJack;

public class BlackJackService : IBlackJackService
{
    private List<Player> _players = [];

    public int PlayerCount => _players.Count;

    public void AddPlayer(Player player) => _players.Add(player);
    public void RemovePlayer(Player player) => _players.Remove(player);

    public void RunGame()
    {
        if (PlayerCount <= 0) throw new ArgumentException("Can't start the game with no players.");
        throw new NotImplementedException();
    }
}
