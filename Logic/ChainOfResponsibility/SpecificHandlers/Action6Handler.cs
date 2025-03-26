using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION6.
    /// </summary>
    public class Action6Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION6";

        /// <summary>
        /// Constructor for <see cref="Action6Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action6Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if(request.IsPinSet 
                && new CardStatus[] { CardStatus.Ordered, CardStatus.Active, CardStatus.Inactive, CardStatus.Blocked }.Contains(request.CardStatus))
            {
                yield return _actionName;
            }
        }
    }
}
