using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground
{
    static class BreadthFirstSearchMetrix
    {
        public static int NumIslands(char[][] grid)
        {
            var height = grid.Length;
            var width = grid[0].Length;

            var traverseDirections = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 0), new Tuple<int, int>(-1, 0), new Tuple<int, int>(0, -1) };
            var visitedCell = new HashSet<string>();

            var currentLocation = FindFirstIsland(grid);
            if(currentLocation.All(x => x == -1)) { return 0; }

            return 1;
        }

        private static int[] FindFirstIsland(char[][] grid)
        {
            int[] currentLocation = { -1, -1 };
            var height = grid.Length;
            var width = grid[0].Length;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        currentLocation[0] = i;
                        currentLocation[1] = j;
                        return currentLocation;
                    }
                }
            }
            return currentLocation;
        }
    }

    public class MatrixNode
    {
        public string Data { set; get; }
        public int Level { get; set; }
    }
}
