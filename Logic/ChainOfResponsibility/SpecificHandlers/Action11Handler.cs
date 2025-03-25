using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION11.
    /// </summary>
    public class Action11Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION11";

        /// <summary>
        /// Constructor for <see cref="Action11Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action11Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if (new CardStatus[] { CardStatus.Active, CardStatus.Inactive }.Contains(request.CardStatus))
            {
                yield return _actionName;
            }
        }
    }
}
