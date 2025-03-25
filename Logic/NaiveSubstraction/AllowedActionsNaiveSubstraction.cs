using Common;

namespace Logic
{
    /// <summary>
    /// Implementation of <see cref="IAllowedActionsService"/> using naive substraction method.
    /// </summary>
    public class AllowedActionsNaiveSubstraction : IAllowedActionsService
    {
        // <inheritdoc />
        public IEnumerable<string> GetAllowedActions(CardParametersDTO cardParameters)
        {
            var allowedActions = new List<string>()
            {
                "ACTION1",
                "ACTION2",
                "ACTION3",
                "ACTION4",
                "ACTION5",
                "ACTION6",
                "ACTION7",
                "ACTION8",
                "ACTION9",
                "ACTION10",
                "ACTION11",
                "ACTION12",
                "ACTION13"
            };
            
            if (cardParameters.CardType == CardType.Prepaid || cardParameters.CardType == CardType.Debit)
                allowedActions.Remove("ACTION5");

            if (cardParameters.CardStatus == CardStatus.Active)
            {
                allowedActions.Remove("ACTION2");

                if (!cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION6");

                if (cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION7");
            }

            if (cardParameters.CardStatus == CardStatus.Blocked)
            {
                allowedActions.Remove("ACTION1");
                allowedActions.Remove("ACTION2");
                allowedActions.Remove("ACTION10");
                allowedActions.Remove("ACTION11");
                allowedActions.Remove("ACTION12");
                allowedActions.Remove("ACTION13");

                if (!cardParameters.IsPinSet)
                {
                    allowedActions.Remove("ACTION6");
                    allowedActions.Remove("ACTION7");
                }
            }

            if (cardParameters.CardStatus == CardStatus.Closed || cardParameters.CardStatus == CardStatus.Expired)
            {
                allowedActions.Remove("ACTION1");
                allowedActions.Remove("ACTION2");
                allowedActions.Remove("ACTION6");
                allowedActions.Remove("ACTION7");
                allowedActions.Remove("ACTION8");
                allowedActions.Remove("ACTION10");
                allowedActions.Remove("ACTION11");
                allowedActions.Remove("ACTION12");
                allowedActions.Remove("ACTION13");
            }

            if (cardParameters.CardStatus == CardStatus.Inactive)
            {
                allowedActions.Remove("ACTION1");

                if (!cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION6");

                if (cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION7");
            }

            if (cardParameters.CardStatus == CardStatus.Ordered)
            {
                allowedActions.Remove("ACTION1");
                allowedActions.Remove("ACTION2");
                allowedActions.Remove("ACTION11");

                if (!cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION6");

                if (cardParameters.IsPinSet)
                    allowedActions.Remove("ACTION7");
            }

            if (cardParameters.CardStatus == CardStatus.Restricted)
            {
                allowedActions.Remove("ACTION1");
                allowedActions.Remove("ACTION2");
                allowedActions.Remove("ACTION6");
                allowedActions.Remove("ACTION7");
                allowedActions.Remove("ACTION8");
                allowedActions.Remove("ACTION10");
                allowedActions.Remove("ACTION11");
                allowedActions.Remove("ACTION12");
                allowedActions.Remove("ACTION13");
            }

            return allowedActions;
        }
    }
}
