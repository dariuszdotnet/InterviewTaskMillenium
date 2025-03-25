using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using InterviewTaskMillenium.Helpers;

namespace InterviewTaskMillenium.ActionFilters
{
    /// <summary>
    /// Action filter responsible for card number format validation.
    /// </summary>
    public class ValidateCardNumberAttribute : ActionFilterAttribute
    {
        private static readonly Regex CardNumberRegex = new(@"^Card(\d)(\d+)$");

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ActionArguments.TryGetValue("cardNumber", out var argumentValue) 
                || argumentValue is not string cardId)
            {
                context.Result = new BadRequestObjectResult(
                    ResultsHelper.GetResultDetails(context.ModelState, "Missing Parameter.", "CardNumber is required.", 400)); 
                return;
            }

            var formatMatch = CardNumberRegex.Match(cardId);
            if (formatMatch.Success == false
                || (int.TryParse(formatMatch.Groups[1].Value, out int userIdNumber) && userIdNumber == 0)
                || (int.TryParse(formatMatch.Groups[2].Value, out int cardIdNumber) && cardIdNumber == 0))
            {
                context.Result = new BadRequestObjectResult(
                    ResultsHelper.GetResultDetails(
                        modelState: context.ModelState, 
                        title: "Invalid Format.", 
                        description: "CardNumber must be in the format 'Card11', 'Card12', 'Card22', etc.", 
                        statusCode: 400));
                return;
            }

            if (userIdNumber != cardIdNumber)
            {
                context.Result = new BadRequestObjectResult(
                    ResultsHelper.GetResultDetails(context.ModelState, "Parameters mismatch.", "CardNumber does not match its UserId.", 400));
                return;
            }

            // SYNTAX DILEMMA EXPLANATION:
            // I find syntax towards one liners more readable (at 4k screen) - current lines 22-23.
            // However I included syntax for same method spread over multiple lines, because I know some people find it more readable - lines 32-37.
            // I always allign with the team syntax.
            // Hoping there is common style guide implemented for a project.
        }
    }
}