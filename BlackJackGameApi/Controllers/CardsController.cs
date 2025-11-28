using System.Threading.Tasks;
using BlackJackGameApi.Database.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackImplementation_November.Models;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

namespace BlackJackGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController(PlayingCardDatabaseContext context) : ControllerBase
    {
        [HttpGet("/{requestedDeckId:int}/{amount:int}")]
        public IActionResult Get(int requestedDeckId, int amount)
        {
            try
            {
                var playingCards = context.Decks.Include(deck => deck.Cards)
                                                .Where(deck => deck.Id == requestedDeckId)
                                                .Select(deck => deck.Cards
                                                                .OrderBy(card => EF.Functions.Random())
                                                                .Select(card => new Card
                                                                                {
                                                                                    Color = card.Color,
                                                                                    Suit = card.Suit,
                                                                                    Value = card.Value
                                                                                })).FirstOrDefault();
                if (playingCards is null || playingCards.Count() == 0) return NotFound(); 
                var stack = new KhStack<Card>();
                foreach (var card in playingCards) stack.Push(card);
                var playingCardService = new PlayingCardService<Card>(stack);
                return Ok(playingCardService.Draw(amount));
            } 
            catch(IndexOutOfRangeException ex)
            {
                return Problem(ex.Message, statusCode: 410);
            }
        }
        [HttpGet("/{requestedDeckId:int}/reset")]
        public IActionResult Get(int requestedDeckId)
        {
            var service = new PlayingCardService<Card>();
            var currentDeck = context.Decks.FirstOrDefault(deck => deck.Id == requestedDeckId);
            return Ok();
        }

        [HttpPost("/new")] //POST til /cards/new
        public async Task<IActionResult> Post(PlayingCardDatabaseContext context)
        {
            var allCards = context.Cards.OrderBy(card => EF.Functions.Random());
            if (allCards is null) return NotFound();
            var newDeck = new DeckEntity();
            foreach (var card in allCards) newDeck.Cards.Add(card);

            context.Decks.Add(newDeck);
            await context.SaveChangesAsync();
            return Ok(newDeck.Id);
        }
        
    }
}
