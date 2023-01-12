using Battleships.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace Battleships.Models
{
    public record UserInput
    {
        public Coordinate Coordinate { get; }

        private UserInput(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public static bool TryCreate(string? input, int gridSize, out UserInput? userInput)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var inputedY = CharToNumber.ToInt(input[0]);
                var inputedX = input[1..];

                if (inputedY > 0 && inputedY <= gridSize &&
                   int.TryParse(inputedX, out var x) && x > 0 && x <= gridSize)
                {
                    userInput = new UserInput(new Coordinate(x - 1, inputedY - 1));
                    return true;
                }
            }

            userInput = null;
            return false;
        }
    }
}
