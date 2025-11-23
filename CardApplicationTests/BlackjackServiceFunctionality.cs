using System;
using StackImplementation_November.Enums.BlackJack;
using StackImplementation_November.Extentions;
using StackImplementation_November.Interfaces.BlackJack;
using StackImplementation_November.Models;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.BlackJack;
using StackImplementation_November.Services.PlayingCard;

namespace CardApplicationTests;



public class BlackjackServiceFunctionality
{

    [Fact]
    public void CanInitiateBlackJackServiceObject()
    {
        IBlackJackGame blackJackService = new BlackJackGame();

        Assert.NotNull(blackJackService);
    }
    [Fact]
    public void CanAddPlayerToGame()
    {
        var newPlayer = new Player("John");
        IBlackJackGame blackJackService = new BlackJackGame();

        blackJackService.AddPlayer(newPlayer);

        Assert.Equal(1, blackJackService.PlayerCount);
    }

    [Fact]
    public void CanRemovePlayerFromGame()
    {
        //Arrange
        var newPlayer = new Player("John");
        IBlackJackGame blackJackService = new BlackJackGame();
        blackJackService.AddPlayer(newPlayer);

        //Act
        blackJackService.RemovePlayer(newPlayer);

        //Assert
        Assert.Equal(0, blackJackService.PlayerCount);
    }

    [Fact]
    public void ThrowsWhenAddingMoreThanFivePlayers()
    {
        IBlackJackGame blackJackService = new BlackJackGame();

        List<Player> players = [
            new ("John"),
            new ("David"),
            new ("James"),
            new ("Linda")
        ];

        foreach (var player in players) blackJackService.AddPlayer(player);

        Assert.Throws<ArgumentException>(()=>blackJackService.AddPlayer(new("Theodore")));
    }

    [Fact]
    public void Test_CanHitCurrentPlayer_WillBustAbove22()
    {
        var cards = new PlayingCardService<Card>();

        Func<Card, int> SortByHighestValue = (Card card) => (int)card.Value;

        cards.SortDeck(card => SortByHighestValue(card));

        var game = new BlackJackGame(cards);

        game.AddPlayer(new Player("John"));

        var player = game.GetCurrentPlayer();

        for (var i = 0; i < 4; i++)
        {
            player.Hit(game);
        }

        Assert.True(player.GetHandScore() > 22);

        Assert.True(player.IsBust);
    }

    [Fact]
    public void Test_IfDealer_HandValueShouldNotChange_AfterHit_IfHandValue_Above_15()
    {
        Dealer dealer = new("John");

        KhStack<Card> cards = [];

        cards.Push(new Card
        {
            Suit = StackImplementation_November.Enums.Suits.Heart,
            Value = StackImplementation_November.Enums.Value.Eight,
            Color = StackImplementation_November.Enums.Color.Red
        });
        cards.Push(new Card
        {
            Suit = StackImplementation_November.Enums.Suits.Diamond,
            Value = StackImplementation_November.Enums.Value.Five,
            Color = StackImplementation_November.Enums.Color.Red
        });
        cards.Push(new Card
        {
            Suit = StackImplementation_November.Enums.Suits.Diamond,
            Value = StackImplementation_November.Enums.Value.King,
            Color = StackImplementation_November.Enums.Color.Red
        });

        var game = new BlackJackGame(new PlayingCardService<Card>(cards));

        game.AddPlayer(dealer);

        var currentPlayer = game.GetCurrentPlayer();
        currentPlayer.Hit(game);
        currentPlayer.Hit(game);

        Assert.Equal(15, currentPlayer.GetHandScore());

        currentPlayer.Hit(game);

        Assert.Equal(15, currentPlayer.GetHandScore());

    }
    

    

}
