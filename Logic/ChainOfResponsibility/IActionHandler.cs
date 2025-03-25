using Common;

namespace Logic
{
    /// <summary>
    /// Interface defining common operations for handling request by specific handler.
    /// </summary>
    public interface IActionHandler
    {
        /// <summary>
        /// Method containing the in order to hande request.
        /// </summary>
        /// <param name="request">Request details encapsulated as <see cref="CardParametersDTO"/> object.</param>
        /// <returns>Collection of allowed actions, dynamically yielded as the request goes through the chain of handlers.</returns>
        IEnumerable<string> Handle(CardParametersDTO request);
    }
}
