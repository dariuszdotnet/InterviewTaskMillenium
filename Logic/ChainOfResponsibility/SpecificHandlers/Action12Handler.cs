using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION12.
    /// </summary>
    public class Action12Handler : AbstractActionHandler
    {
        private static string _actionName = "ACTION12";

        /// <summary>
        /// Constructor for <see cref="Action12Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action12Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if (new CardStatus[] { CardStatus.Ordered, CardStatus.Active, CardStatus.Inactive }.Contains(request.CardStatus))
            {
                yield return _actionName;
            }
        }
    }
}
