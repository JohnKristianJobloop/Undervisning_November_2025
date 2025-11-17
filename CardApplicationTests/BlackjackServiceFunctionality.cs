using System;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Services.BlackJack;

namespace CardApplicationTests;



public class BlackjackServiceFunctionality
{

    [Fact]
    public void CanInitiateBlackJackServiceObject()
    {
        IBlackJackService blackJackService = new BlackJackService();

        Assert.NotNull(blackJackService);
    }
    [Fact]
    public void CanAddPlayerToGame()
    {
        var newPlayer = new Player("John");
        IBlackJackService blackJackService = new BlackJackService();

        blackJackService.AddPlayer(newPlayer);

        Assert.Equal(1, blackJackService.PlayerCount);
    }

    [Fact]
    public void CanRemovePlayerFromGame()
    {
        //Arrange
        var newPlayer = new Player("John");
        IBlackJackService blackJackService = new BlackJackService();
        blackJackService.AddPlayer(newPlayer);

        //Act
        blackJackService.RemovePlayer(newPlayer);

        //Assert
        Assert.Equal(0, blackJackService.PlayerCount);
    }

    [Fact]
    public void StartGameThrowsWithNoPlayersInGame()
    {
        IBlackJackService blackJackService = new BlackJackService();

        Assert.Throws<ArgumentException>(blackJackService.RunGame);
    }

    [Fact]
    public void ThrowsWhenAddingMoreThanFivePlayers()
    {
        IBlackJackService blackJackService = new BlackJackService();

        List<Player> players = [
            new ("John"),
            new ("David"),
            new ("James"),
            new ("Linda")
        ];

        foreach (var player in players) blackJackService.AddPlayer(player);

        Assert.Throws<ArgumentException>(()=>blackJackService.AddPlayer(new("Theodore")));
    }

    

    

}
