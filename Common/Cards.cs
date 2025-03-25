namespace Common
{
    /// <summary>
    /// Enum representing the type of the card.
    /// </summary>
    public enum CardType
    {
        Prepaid,
        Debit,
        Credit
    }

    /// <summary>
    /// Enum representing the status of the card.
    /// </summary>
    public enum CardStatus
    {
        Ordered,
        Inactive,
        Active,
        Restricted,
        Blocked,
        Expired,
        Closed
    }

    /// <summary>
    /// Record representing the card details.
    /// </summary>
    /// <param name="CardNumber">Number of the card.</param>
    /// <param name="CardType">Object of type <see cref="Common.CardType"/> defining type of the card.</param>
    /// <param name="CardStatus">Object of type <see cref="Common.CardStatus"/> representing status of the card.</param>
    /// <param name="IsPinSet">Indicates whether the PIN is set. <c>true</c> if the PIN is set; otherwise <c>false</c>.</param>
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);

    /// <summary>
    /// Record struct representing the card details.
    /// </summary>
    /// <param name="cardNumber">Number of the card.</param>
    /// <param name="CardType">Object of type <see cref="Common.CardType"/> defining type of the card.</param>
    /// <param name="CardStatus">Object of type <see cref="Common.CardStatus"/> representing status of the card.</param>
    /// <param name="IsPinSet">Indicates whether the PIN is set. <c>true</c> if the PIN is set; otherwise <c>false</c>.</param>
    public record struct CardParametersDTO(CardType CardType, CardStatus CardStatus, bool IsPinSet);    
}
