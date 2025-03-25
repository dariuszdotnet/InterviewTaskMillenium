using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION5.
    /// </summary>
    public class Action5Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION5";

        /// <summary>
        /// Constructor for <see cref="Action5Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action5Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if(request.CardType == CardType.Credit)
            {
                yield return _actionName;
            }
        }
    }
}
