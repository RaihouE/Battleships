using Battleships.Models;

namespace Battleships.Tests
{
    public class UserInputTests
    {
        [Theory]
        [InlineData("A5", 10)]
        public void UserInput_IsCorrect(string input, int gridSize)
        {
            var isUserInputValid = UserInput.TryCreate(input, gridSize, out var userInput);

            Assert.True(isUserInputValid);
            Assert.NotNull(userInput);
            Assert.Equal(0, userInput.Coordinate.Y);
            Assert.Equal(4, userInput.Coordinate.X);
        }
    }
}