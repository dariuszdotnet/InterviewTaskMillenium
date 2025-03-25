using Common;

namespace Logic.Tests
{
    public class AllowedActionsCoRTests
    {
        [Theory]

        [InlineData(CardType.Prepaid, CardStatus.Ordered, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Inactive, true, 
            new string[] { "ACTION2", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Active, true, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Restricted, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Blocked, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION6", "ACTION7", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Expired, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Closed, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]

        [InlineData(CardType.Debit, CardStatus.Ordered, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Inactive, true, 
            new string[] { "ACTION2", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Active, true, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Restricted, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Blocked, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION6", "ACTION7", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Expired, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Closed, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]

        [InlineData(CardType.Credit, CardStatus.Ordered, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Inactive, true, 
            new string[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Active, true, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Restricted, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Blocked, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Expired, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Closed, true, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]

        [InlineData(CardType.Prepaid, CardStatus.Ordered, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Inactive, false, 
            new string[] { "ACTION2", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Active, false, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Prepaid, CardStatus.Restricted, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Blocked, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Expired, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Prepaid, CardStatus.Closed, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]

        [InlineData(CardType.Debit, CardStatus.Ordered, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Inactive, false, 
            new string[] { "ACTION2", "ACTION3", "ACTION4","ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Active, false, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Debit, CardStatus.Restricted, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Blocked, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Expired, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]
        [InlineData(CardType.Debit, CardStatus.Closed, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION9", })]

        [InlineData(CardType.Credit, CardStatus.Ordered, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Inactive, false, 
            new string[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Active, false, 
            new string[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [InlineData(CardType.Credit, CardStatus.Restricted, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Blocked, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Expired, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]
        [InlineData(CardType.Credit, CardStatus.Closed, false, 
            new string[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9", })]
        public void GetAllowedActions_ShouldReturnExpectedActions_WhenCardStatusIsActive
            (CardType cardType, CardStatus cardStatus, bool isPinSet, string[] expectedAllowedActions)
        {
            // Arrange
            var cardParameters = new CardParametersDTO(cardType, cardStatus, isPinSet);
            var allowedActionsCoR = new AllowedActionsCoR();

            // Act
            var result = allowedActionsCoR.GetAllowedActions(cardParameters);

            // Assert
            Assert.Equal(expectedAllowedActions, result);
        }
    }
}