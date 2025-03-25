using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION7.
    /// </summary>
    public class Action7Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION7";

        /// <summary>
        /// Constructor for <see cref="Action7Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action7Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if (request.IsPinSet 
                && new CardStatus[] { CardStatus.Active, CardStatus.Inactive }.Contains(request.CardStatus))
            {
                yield return _actionName;
            }
        }
    }
}
