using System;
using StackImplementation_November.Models.BlackJack;
using StackImplementation_November.Models.PlayingCard;

namespace CardApplicationTests;

public class PlayerFunctionalityTest
{
    [Fact]
    public void NewPlayer_WithEmptyHand_ShouldReturnZeroHandValue()
    {
        var newPlayer = new Player("John");

        Assert.Equal(0, newPlayer.CurrentHandValue);
    }


    [Fact]
    public void PlayerWithCards_TwoOfHeartAndThreeOfHeart_ShouldReturnFiveHandValue()
    {
        var newPlayer = new Player("John", [new Card{
            Color = StackImplementation_November.Enums.Color.Red,
            Suit = StackImplementation_November.Enums.Suits.Heart,
            Value = StackImplementation_November.Enums.Value.Two
        }, new Card{
            Color = StackImplementation_November.Enums.Color.Red,
            Suit = StackImplementation_November.Enums.Suits.Heart,
            Value = StackImplementation_November.Enums.Value.Three
        }]);

        Assert.Equal(5, newPlayer.CurrentHandValue);
    }

    [Fact]
    public void PlayerWithCards_KingOfSpadesAndTenOfDiamonds_ShouldReturnTwentyHandValue()
    {
        
        var newPlayer = new Player("John",
        [
            new Card{
                Color = StackImplementation_November.Enums.Color.Black,
                Suit = StackImplementation_November.Enums.Suits.Spades,
                Value = StackImplementation_November.Enums.Value.King
            },
            new Card{
                Color = StackImplementation_November.Enums.Color.Red,
                Suit = StackImplementation_November.Enums.Suits.Diamond,
                Value = StackImplementation_November.Enums.Value.Ten
            }
        ]);
        Assert.Equal(20, newPlayer.CurrentHandValue);
    }

    [Fact]
    public void PlayerWithCards_AceOfSpacesAndTenOfDiamonds_ShouldReturnTwentyOneHandValue()
    {
        var newPlayer = new Player("John",
        [
            new Card{
                Color = StackImplementation_November.Enums.Color.Black,
                Suit = StackImplementation_November.Enums.Suits.Spades,
                Value = StackImplementation_November.Enums.Value.Ace
            }, 
            new Card{
                Color = StackImplementation_November.Enums.Color.Red,
                Suit = StackImplementation_November.Enums.Suits.Diamond,
                Value = StackImplementation_November.Enums.Value.Ten
            }
        ]);

        Assert.Equal(21, newPlayer.CurrentHandValue);
    }
    [Fact]
    public void PlayerWithCards_AceOfHeartAndAceOfDiamondsAndFiveOfClubs_ShouldReturnSevenTeen()
    {
        var newPlayer = new Player("John",
        [
            new Card{
                Color= StackImplementation_November.Enums.Color.Red,
                Suit = StackImplementation_November.Enums.Suits.Heart,
                Value = StackImplementation_November.Enums.Value.Ace
            },
            new Card{
                Color= StackImplementation_November.Enums.Color.Red,
                Suit = StackImplementation_November.Enums.Suits.Diamond,
                Value = StackImplementation_November.Enums.Value.Ace
            },
            new Card{
                Color= StackImplementation_November.Enums.Color.Red,
                Suit = StackImplementation_November.Enums.Suits.Heart,
                Value = StackImplementation_November.Enums.Value.Five
            }
        ]
        );

        Assert.Equal(17, newPlayer.CurrentHandValue);
        
    }
}
