using Common;

namespace Logic
{
    /// <summary>
    /// Implementation of <see cref="IAllowedActionsService"/> using Chain of Responsibility pattern.
    /// </summary>
    public class AllowedActionsCoR : IAllowedActionsService
    {
        private readonly IActionHandler _firstHandler;

        /// <summary>
        /// Constructor for <see cref="AllowedActionsCoR"/>.
        /// </summary>
        public AllowedActionsCoR()
        {
            _firstHandler = new Action1Handler(
                            new Action2Handler(
                            new Action3Handler(
                            new Action4Handler(
                            new Action5Handler(
                            new Action6Handler(
                            new Action7Handler(
                            new Action8Handler(
                            new Action9Handler(
                            new Action10Handler(
                            new Action11Handler(
                            new Action12Handler(
                            new Action13Handler(null!)))))))))))));
        }

        // <inheritdoc />
        public IEnumerable<string> GetAllowedActions(CardParametersDTO cardParameters)
        {
            IEnumerable<string> allowedActions = _firstHandler.Handle(cardParameters);
            return allowedActions;
        }
    }
}