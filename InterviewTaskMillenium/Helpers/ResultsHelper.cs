using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InterviewTaskMillenium.Helpers
{
    /// <summary>
    /// Helper class related to results returned from endpoints.
    /// </summary>
    public static class ResultsHelper
    {
        /// <summary>
        /// Method encapsulating the creation of <see cref="ValidationProblemDetails"/> object.
        /// </summary>
        /// <param name="modelState">Model state.</param>
        /// <param name="title">Title of the response.</param>
        /// <param name="description">Detailed description attached to the response.</param>
        /// <param name="statusCode">Status code of the response.</param>
        /// <returns></returns>
        public static ValidationProblemDetails GetResultDetails(ModelStateDictionary modelState, string title, string description, int statusCode)
        {
            return new ValidationProblemDetails(modelState)
            {
                Title = title,
                Status = statusCode,
                Detail = description
            };
        }
    }
}
