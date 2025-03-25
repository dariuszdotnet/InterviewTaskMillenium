using Common;
using Moq;

namespace Logic.Tests
{
    public class Action1HandlerTests
    {
        [Fact]
        public void HandleAction_ShouldReturnActionName_WhenCardStatusIsActive()
        {
            // Arrange
            var handler = new Action1Handler(null!);
            var request = new CardParametersDTO(CardType.Credit, CardStatus.Active, true);

            // Act
            var result = handler.Handle(request);

            // Assert
            Assert.Contains("ACTION1", result);
        }

        [Fact]
        public void HandleAction_ShouldNotReturnActionName_WhenCardStatusIsNotActive()
        {
            // Arrange
            var nextHandler = new Mock<IActionHandler>().Object;
            var handler = new Action1Handler(nextHandler);
            var request = new CardParametersDTO(CardType.Credit, CardStatus.Inactive, true);

            // Act
            var result = handler.Handle(request);

            // Assert
            var expected = 0;
            Assert.Equal(result.Count(), expected);
        }
    }
}