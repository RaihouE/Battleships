using Battleships.Helpers;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Battleships.Tests
{
    public class GridTests
    {
        [Theory]
        [InlineData(10, new[] { 4, 4, 5 })]
        public void Grid_IsPopulatedWithNonOverlapingShips(int gridSize, int[] ships)
        {
            var grid = GridBuilder.InitGrid(gridSize, ships);

            var shipsToCheck = ships.Sum();

            var shipsInGrid = grid.Count(g => g.Value == State.Ship);

            Assert.Equal(shipsToCheck, shipsInGrid);
        }
    }
}
