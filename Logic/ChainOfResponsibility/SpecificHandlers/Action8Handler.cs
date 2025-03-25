using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION8.
    /// </summary>
    public class Action8Handler : AbstractActionHandler
    {
        private static string _actionName = "ACTION8";

        /// <summary>
        /// Constructor for <see cref="Action8Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action8Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if(new CardStatus[] { CardStatus.Ordered, CardStatus.Active, CardStatus.Inactive, CardStatus.Blocked }.Contains(request.CardStatus))
            {
                yield return _actionName;
            }
        }
    }
}
