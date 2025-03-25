using Common;
using Data;
using InterviewTaskMillenium.ActionFilters;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTaskMillenium.Controllers
{
    /// <summary>
    /// Controller dedicated for operations related to cards.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IAllowedActionsService _allowedActions;
        private readonly ILogger<CardsController> _logger;

        /// <summary>
        /// Constructor for <see cref="CardsController".
        /// </summary>
        /// <param name="cardService">Service for providing and retrieving cards. Should implement <see cref="ICardService".</param>
        /// <param name="allowedActionsService">Service defining logic related to calculation of allowed actions per specific card.</param>
        /// <param name="logger">Instance of logger.</param>
        public CardsController(ICardService cardService, IAllowedActionsService allowedActionsService, ILogger<CardsController> logger)
        {
            _cardService = cardService;
            _allowedActions = allowedActionsService;
            _logger = logger;
        }

        /// <summary>
        /// Method responsible for retrieving allowed actions for a specific card.
        /// </summary>
        /// <param name="userId">User identifier. Must be in a format <c>User1</c>, <c>User2</c> etc.</param>
        /// <param name="cardNumber">Card identifier. Must be in a format <c>Card11</c>, <c>Card12</c>, <c>Card22</c> etc.</param>
        /// <returns>If success returns OK response with JSON containing allowed actions names, uppercase. If the card was not found, it would return NotFound response.</returns>
        [HttpGet]
        [Route("/allowedactions/{userId}/{cardNumber}")]
        [ValidateUserId]
        [ValidateCardNumber]
        public async Task<IActionResult> GetAllowedActions([FromRoute] string userId, [FromRoute] string cardNumber)
        {
            var card = await _cardService.GetCardDetails(userId, cardNumber);
            if(card == null)
            {
                _logger.LogTrace($"Method {nameof(GetAllowedActions)} executed, but card wasn't found.");
                return NotFound();
            }

            var allowedActions = _allowedActions.GetAllowedActions(
                new CardParametersDTO(card.CardType, card.CardStatus, card.IsPinSet)).ToArray();

            _logger.LogTrace($"Method {nameof(GetAllowedActions)} executed with success.");
            return Ok(new { allowed_actions = allowedActions });

            // FURTHER IMPROVEMENT PROPOSAL: 
            // Replace underscore for a space inside JSON structure (allowed_actions).
            // This would require a class with a single property tagged with a [JsonPropertyName("allowed actions")].
            // Might improve readability of the response.
        }
    }
}