using Common;

namespace Data
{
    /// <summary>
    /// Service responsible for creation of cards as well as retrieving its details.
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Retrieving card details from a service.
        /// </summary>
        /// <param name="userId">User identifier in a format <c>User1</c>, <c>User2</c> etc.</param>
        /// <param name="cardNumber">Card indentifier in a format <c>Card11</c>, <c>Card12</c>, <c>Card22</c> etc.</param>
        /// <returns>Details related to specific card as an object of type <see cref="CardDetails"/></returns>
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
    }
}