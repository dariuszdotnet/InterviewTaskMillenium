using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using InterviewTaskMillenium.Helpers;

namespace InterviewTaskMillenium.ActionFilters
{
    /// <summary>
    /// Action filter responsible for user identifier format validation.
    /// </summary>
    public class ValidateUserIdAttribute : ActionFilterAttribute
    {
        private static readonly Regex UserIdRegex = new(@"^User(\d+)$");

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ActionArguments.TryGetValue("userId", out var value) 
                || value is not string userId)
            {
                context.Result = new BadRequestObjectResult(
                    ResultsHelper.GetResultDetails(context.ModelState, "Missing Parameter.", "UserId is required.", 400));
                return;
            }

            var formatMatch = UserIdRegex.Match(userId);
            if (formatMatch.Success == false 
                || int.TryParse(formatMatch.Groups[1].Value, out int userIdNumber) && userIdNumber == 0)
            {
                context.Result = new BadRequestObjectResult(
                    ResultsHelper.GetResultDetails(
                        modelState: context.ModelState,
                        title: "Invalid Format.",
                        description: "UserId must be in the format 'User1', 'User2', etc.",
                        statusCode: 400));
                return;
            }
        }
    }
}
