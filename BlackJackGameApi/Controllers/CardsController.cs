using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

namespace BlackJackGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController(PlayingCardService<Card> service) : ControllerBase
    {
        [HttpGet("/{amount:int}")]
        public IActionResult Get(int amount)
        {
            try
            {
                return Ok(service.Draw(amount));
            } 
            catch(IndexOutOfRangeException ex)
            {
                return Problem(ex.Message, statusCode: 410);
            }
        }
        [HttpGet("/reset")]
        public IActionResult Get()
        {
            service.ResetDeck();
            return Ok();
        }

        [HttpPost("/new")] //POST til /cards/new
        public IActionResult Post([FromQuery]Card newCard)
        {
            try
            {
                service.ShuffleCardBackIntoDeck(newCard);
                return Ok();
            }
            catch (IndexOutOfRangeException ex)
            {
                return Problem(ex.Message);
            }
        }
        
    }
}
