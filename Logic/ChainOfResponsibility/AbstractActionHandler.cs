using Common;

namespace Logic
{
    /// <summary>
    /// Abstract class defining common operations for handling request by specific handlers.
    /// </summary>
    public abstract class AbstractActionHandler : IActionHandler
    {
        protected IActionHandler? _nextHandler; // ? question mark here should it be? check this with null here and in other places

        /// <summary>
        /// Name of the handler.
        /// </summary>
        protected string Name { get; }

        /// <summary>
        /// Constructor for the handler.
        /// </summary>
        /// <param name="name">Name of the handler.</param>
        /// <param name="nextHandler">Handler that has to be next in the chain.</param>
        protected AbstractActionHandler(string name, IActionHandler nextHandler)
        {
            Name = name;
            this._nextHandler = nextHandler;
        }

        /// <summary>
        /// Method handling the process of yielding the results into a common collection
        /// as well as passing the request into next handler in the chain. 
        /// </summary>
        /// <param name="request">Card details encapsulated as DTO object.</param>
        /// <returns>Collection containing allowed actions.</returns>
        public virtual IEnumerable<string> Handle(CardParametersDTO request)
        {
            foreach (var action in HandleAction(request))
            {
                yield return action;
            }

            if (_nextHandler != null)
            {
                foreach (var handler in _nextHandler.Handle(request))
                {
                    yield return handler;
                }
            }
        }

        /// <summary>
        /// Abstract method, required to be implemented by every specific handler.
        /// Defines the logic wether to include specific action or not.
        /// </summary>
        /// <param name="request">Card details encapsulated as DTO object.</param>
        /// <returns>Collection containing allowed actions.</returns>
        protected abstract IEnumerable<string> HandleAction(CardParametersDTO request);
    }
}

// EXPLANATION OF THE DILLEMA BETWEEN COR PATTERN VERSIONS:
// The version I choosed is to pass next handlers in the chain via constructor, instead seperated method - for code size in the client.
// If the need for setting next handler dynamically arises, it can be done by adding a method to set next handler.