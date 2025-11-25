using System;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

namespace CardApplicationTests;

public class PlayingCardServiceTest
{
    [Fact]
    public void TestCanCreateService()
    {
        //Arrange

        //Act
        var service = new PlayingCardService<Card>();
        //Assert
        Assert.NotNull(service);
        Assert.Equal(52, service.Count);
    }

    [Fact]
    public void TestCreateServiceAndPopulateWithCards()
    {
        //Arrange

        var service = new PlayingCardService<Card>();

        //Assert
        Assert.NotNull(service.Draw(1).FirstOrDefault());
    }

    [Fact]
    public void TestCreateServiceAndDeckIsShuffled()
    {
        //Arrange
        var service = new PlayingCardService<Card>();

        var DrawnCards = service.Draw(10).ToList();

        var firstDrawnCard = DrawnCards.FirstOrDefault();

        //Assert

        //Dette er egentlig en dårlig test, siden den har 1/52 sjanse for å breake randomly.
        Assert.NotEqual("Black Ace of Clubs", firstDrawnCard.Name, StringComparer.OrdinalIgnoreCase);
    }

}

