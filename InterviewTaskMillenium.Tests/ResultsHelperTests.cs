using Microsoft.AspNetCore.Mvc.ModelBinding;
using InterviewTaskMillenium.Helpers;

namespace InterviewTaskMillenium.Tests
{
    public class ResultsHelperTests
    {
        [Fact]
        public void GetResultDetails_ShouldReturnValidationProblemDetails_WithCorrectValues()
        {
            // Arrange
            var modelState = new ModelStateDictionary();
            string title = "some test title";
            string description = "some test description";
            int statusCode = 400;

            // Act
            var details = ResultsHelper.GetResultDetails(modelState, title, description, statusCode);

            // Assert
            Assert.NotNull(details);
            Assert.Equal(title, details.Title);
            Assert.Equal(description, details.Detail);
            Assert.Equal(statusCode, details.Status);
        }
    }
}