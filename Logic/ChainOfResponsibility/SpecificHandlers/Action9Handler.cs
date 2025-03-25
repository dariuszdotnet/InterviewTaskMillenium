using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION9.
    /// </summary>
    public class Action9Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION9";

        /// <summary>
        /// Constructor for <see cref="Action9Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action9Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            yield return _actionName;
        }
    }
}
