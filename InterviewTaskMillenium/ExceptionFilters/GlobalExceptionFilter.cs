using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using InterviewTaskMillenium.Helpers;

namespace InterviewTaskMillenium.ExceptionFilters
{
    /// <summary>
    /// Global exception filter for handling unexpected exceptions.
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly string _message = "An unexpected error occurred.";

        /// <summary>
        /// Constructor for <see cref="GlobalExceptionFilter"/>.
        /// </summary>
        /// <param name="logger">Instace of the logger.</param>
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"{_message}: {context.Exception.Message}");

            context.Result = new ObjectResult(
                ResultsHelper.GetResultDetails(context.ModelState, "Unexpected error.", _message, 500));
        }
    }
}
