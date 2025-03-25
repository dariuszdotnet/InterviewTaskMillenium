using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION1.
    /// </summary>
    public class Action1Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION1";

        /// <summary>
        /// Constructor for <see cref="Action1Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action1Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if (request.CardStatus == CardStatus.Active)
            {
                yield return _actionName;
            }
        }
    }
}
