using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION2.
    /// </summary>
    public class Action2Handler : AbstractActionHandler
    {
        private static string _actionName = "ACTION2";

        /// <summary>
        /// Constructor for <see cref="Action2Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action2Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            if (request.CardStatus == CardStatus.Inactive)
            {
                yield return _actionName;
            }
        }
    }
}
