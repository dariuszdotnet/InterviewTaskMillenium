using Common;

namespace Logic
{
    /// <summary>
    /// Specific handler for ACTION4.
    /// </summary>
    public class Action4Handler : AbstractActionHandler
    {
        private static readonly string _actionName = "ACTION4";

        /// <summary>
        /// Constructor for <see cref="Action4Handler"/>.
        /// </summary>
        /// <param name="nextHandler">Handler to be set as next in the chain.</param>
        public Action4Handler(IActionHandler nextHandler) : base(_actionName, nextHandler) { }

        // <inheritdoc/>
        protected override IEnumerable<string> HandleAction(CardParametersDTO request)
        {
            yield return _actionName;
        }
    }
}
