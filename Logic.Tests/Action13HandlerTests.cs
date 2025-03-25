using Common;
using Moq;

namespace Logic.Tests
{
    public class Action13HandlerTests
    {
        [Fact]
        public void HandleAction_ShouldReturnActionName_WhenCardStatusIsActive()
        {
            // Arrange
            var handler = new Action13Handler(null!);
            var request = new CardParametersDTO(CardType.Credit, CardStatus.Active, true);

            // Act
            var result = handler.Handle(request);

            // Assert
            Assert.Contains("ACTION13", result);
        }

        [Theory]
        [InlineData(CardStatus.Ordered, 1)]
        [InlineData(CardStatus.Active, 1)]
        [InlineData(CardStatus.Inactive, 1)]
        [InlineData(CardStatus.Restricted, 0)]
        [InlineData(CardStatus.Blocked, 0)]
        public void HandleAction_ShouldReturnProperCollectionContent_DependingOnCardStatus(CardStatus cardStatus, int expectedCollectionCount)
        {
            // Arrange
            var nextHandler = new Mock<IActionHandler>().Object;
            var handler = new Action13Handler(nextHandler);
            var request = new CardParametersDTO(CardType.Credit, cardStatus, true);

            // Act
            var result = handler.Handle(request);

            // Assert
            Assert.Equal(result.Count(), expectedCollectionCount);
        }
    }
}