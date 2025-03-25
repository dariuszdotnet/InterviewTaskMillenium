using Common;
using Data;
using InterviewTaskMillenium.Controllers;
using InterviewTaskMillenium.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace InterviewTaskMillenium.Tests
{
    public class CardsControllerTests
    {
        private readonly Mock<ICardService> _mockCardService;
        private readonly Mock<IAllowedActionsService> _mockAllowedActionsService;
        private readonly Mock<ILogger<CardsController>> _mockLogger;
        private readonly CardsController _controller;

        public CardsControllerTests()
        {
            _mockCardService = new Mock<ICardService>();
            _mockAllowedActionsService = new Mock<IAllowedActionsService>();
            _mockLogger = new Mock<ILogger<CardsController>>();
            _controller = new CardsController(_mockCardService.Object, _mockAllowedActionsService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllowedActions_ShouldReturnNotFound_WhenCardIsNotFound()
        {
            // Arrange
            _mockCardService.Setup(service => service.GetCardDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((CardDetails)null!);

            // Act
            var result = await _controller.GetAllowedActions("User1", "Card11");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllowedActions_ShouldReturnOk_WithAllowedActions()
        {
            // Arrange
            var card = new CardDetails("Card11", CardType.Credit, CardStatus.Active, true);
            _mockCardService.Setup(service => service.GetCardDetails(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(card);
            _mockAllowedActionsService.Setup(service => service.GetAllowedActions(It.IsAny<CardParametersDTO>())).Returns(new[] { "ACTION1", "ACTION2" });

            // Act
            var result = await _controller.GetAllowedActions("User1", "Card11");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<AllowedActionsResponse>(okResult.Value);
            var expected = new[] { "ACTION1", "ACTION2" };
            Assert.Equal(expected, response.AllowedActions);
        }
    }
}
