using Common;

namespace Logic
{
    /// <summary>
    /// Interface defining logic related to calculation of allowed actions per specific card.
    /// </summary>
    public interface IAllowedActionsService
    {
        /// <summary>
        /// Method responsible for calculating allowed actions for a specific card.
        /// </summary>
        /// <param name="cardParameters">Card parameters as DTO object <see cref="CardParametersDTO"/> containing card's type, status and boolean wether PIN is set.</param>
        /// <returns>Collection containing action names, uppercase.</returns>
        IEnumerable<string> GetAllowedActions(CardParametersDTO cardParameters);
    }
}