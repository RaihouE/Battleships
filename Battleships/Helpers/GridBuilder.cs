using Battleships.Models;

namespace Battleships.Helpers
{
    public class GridBuilder
    {
        public static Dictionary<Coordinate, State> InitGrid(int gridSize, IEnumerable<int> ships)
        {
            var grid = new Dictionary<Coordinate, State>();

            foreach (var ship in ships)
            {
                var isShipPlaced = false;

                while (!isShipPlaced)
                {
                    var randomX = Random.Shared.Next(0, gridSize - 1);
                    var randomY = Random.Shared.Next(0, gridSize - 1);

                    var xAxisShipCoords = new List<Coordinate>();
                    var yAxisShipCoords = new List<Coordinate>();
                    for (var i = 0; i < ship; i++)
                    {
                        xAxisShipCoords.Add(new Coordinate(randomX + i, randomY));
                        yAxisShipCoords.Add(new Coordinate(randomX, randomY + i));
                    }

                    if (xAxisShipCoords.Last().X < gridSize && !grid.Any(g => xAxisShipCoords.Contains(g.Key)))
                    {
                        foreach (var cord in xAxisShipCoords)
                        {
                            grid[cord] = State.Ship;
                        }
                        isShipPlaced = true;
                    }
                    else if (yAxisShipCoords.Last().Y < gridSize && !grid.Any(g => yAxisShipCoords.Contains(g.Key)))
                    {
                        foreach (var cord in yAxisShipCoords)
                        {
                            grid[cord] = State.Ship;
                        }
                        isShipPlaced = true;
                    }
                }

            }

            for (var x = 0; x < gridSize; x++)
            {
                for (var y = 0; y < gridSize; y++)
                {
                    if(!grid.ContainsKey(new Coordinate(x, y)))
                    {
                        grid[new Coordinate(x, y)] = State.Empty;
                    }
                }
            }

            return grid;

        }
    }
}
