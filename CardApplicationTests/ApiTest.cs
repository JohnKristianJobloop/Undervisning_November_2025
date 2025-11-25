using System;
using System.Net.Http.Json;
using StackImplementation_November.Models.PlayingCard;

namespace CardApplicationTests;

public class ApiTest
{
    private readonly HttpClient _client = new();

    [Fact]
    public async Task TestApiCalls_ShouldReturn_SuccessStatusCode()
    {
        var reponse = await _client.GetAsync("http://localhost:5274/cards/10");
        Assert.Equal(200, (int)reponse.StatusCode);
    }

    [Fact]
    public async Task TestApiCalls_ShouldReturn_ListOfTenCards()
    {
        var response = await _client.GetAsync("http://localhost:5274/cards/10");
        var cards = await response.Content.ReadFromJsonAsync<List<Card>>();

        Assert.NotNull(cards);
        Assert.NotEmpty(cards);
        Assert.Equal(10, cards.Count);
    }
}
