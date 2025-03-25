using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION3.
    /// </summary>
    public class Action3Handler : AbstractActionHandler
    {
        private static string _actionName = "ACTION3";

        /// <summary>
        /// Constructor for <see cref="Action3Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action3Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            yield return _actionName;
        }
    }
}
