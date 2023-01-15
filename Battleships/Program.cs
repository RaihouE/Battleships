using Battleships.Helpers;
using Battleships.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var ships = new List<int> { 4, 4, 5 };
        var gridSize = 10;
        var maxScore = ships.Sum();
        var currentScore = 0;
        var grid = GridBuilder.InitGrid(gridSize, ships);

        Console.WriteLine("Welcome to single player battleships");
        Console.WriteLine("Your goal is to hit {0} length ships", string.Join(",", ships));
        Console.WriteLine();
        while (currentScore < maxScore)
        {
            DrawGrid(grid, gridSize);
            var userInput = GetUserInput(gridSize);

            var newState = grid[userInput.Coordinate] switch
            {
                State.Ship => State.Hit,
                _ => State.Miss
            };

            grid[userInput.Coordinate] = newState;

            if(newState == State.Hit)
            {
                currentScore++;
            }

            Console.WriteLine("It was a {0}!", newState.ToString());
        }

        Console.WriteLine();
        Console.WriteLine("Congratulations, You Have Won!");
        Console.WriteLine("Press any key to close the game");
        Console.ReadKey();
    }

    private static UserInput GetUserInput(int gridSize)
    {
        var isInputValid = false;
        UserInput? userInput = null;
        while (!isInputValid && userInput is null)
        {
            Console.WriteLine();
            Console.WriteLine("Please input coordinates to hit a ship! eg A5");
            Console.WriteLine();
            var input = Console.ReadLine();
            isInputValid = UserInput.TryCreate(input, gridSize, out userInput);
        }

        return userInput!;
    }

    private static void DrawGrid(Dictionary<Coordinate, State> grid, int gridSize)
    {
        var gridArray = new State[gridSize, gridSize];

        foreach (var coord in grid)
        {
            gridArray[coord.Key.X, coord.Key.Y] = coord.Value;
        }

        for (var x = 0; x < gridSize; x++)
        {
            Console.Write("[{0}]", x + 1);
        }
        Console.WriteLine();


        for (var y = 0; y < gridSize; y++)
        {
            for (var x = 0; x < gridSize; x++)
            {
                var symbol = gridArray[x, y] switch
                {
                    State.Miss => "o",
                    State.Hit => "x",
                    _ => " "
                };
                Console.Write("[{0}]", symbol);
            }
            Console.Write("[{0}]", CharToNumber.FromInt(y + 1));
            Console.WriteLine();
        }
    }
}