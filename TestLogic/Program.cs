using System;
using System.Collections.Generic;
using System.Linq;
using TestLogic.CanJump;
using TestLogic.ContainerWithMostWater;
using TestLogic.LongestCommonPrefix;
using TestLogic.ReverseInteger;
using TestLogic.ThreeSum;
using TestLogic.TwoSum;

namespace TestLogic
{
    class Program
    {
        static void Main(string[] args)
        {
			var canJumpInput = new int[] { 2, 3, 1, 1, 4 };
			var canJumpResult = CanJumpClass.CanJump(canJumpInput);
			Console.WriteLine(canJumpResult);
			//var nums = new int[] { 2, 7, 11, 15 };
			//var target = 9;
			//var result = TwoSumClass.TwoSumMethod(nums, target);
			//Console.WriteLine($"{result[0]} , {result[1]} ");
			//var input = new int[] { -1, 0, 1, 2, -1, -4 };
			//var output = ThreeSumClass.ThreeSum(input).ToList();
			//output.ForEach(x => Console.WriteLine(string.Join(",", x)));

			//var reverseInteger = new ReverseIntegerClass();
			//var result = reverseInteger.ReverseIntegerMethod(-123);
			//Console.WriteLine(result);
		}

		public static int TraverseBFS(int[][] grid)
		{
			var jaggedGrid = new int[][]
{
				new int[] { 2, 0, 1, 1},
				new int[] { 1, 1, 1, 1},
				new int[] { 1, 0, 1, 1},
				new int[] { 0, 1, 0, 0}
};

			var rottenDays = TraverseBFS(jaggedGrid);

			Console.WriteLine($"=={rottenDays}==");
			int height = grid.Length;
			int width = grid[0].Length;
			int totalRottenDay = 0;
			var countingResult = CountFreshOrange(grid, height, width);
			var totalGoodOrange = countingResult.TotalGoodOrange;
			var startPoints = countingResult.StartPoint;

			if (startPoints.Count == 0)
				return 0;

			var visited = new int[height, width];
			var rottenDayTracker = new int[height, width];

			Queue<KeepTrackObject> keepTrack = new Queue<KeepTrackObject>();
			// right, down, up, left 
			// height width
			int[] fourDirections = new int[] { 0, 1, 1, 0, -1, 0, 0, -1 };


			// no depth first search is utilizing stack!! it could be your CALL STACK  
			// breath first search is to see if 
			foreach(var startPoint in startPoints)
			{
				var startObject = new KeepTrackObject() { VisitedHeight = startPoint[0], VisitedWidth = startPoint[1], RottenDay = 0 };
				keepTrack.Enqueue(startObject);
			}
			while (keepTrack.Count > 0)
			{
				var visitedCordinate = keepTrack.Dequeue();
				visited[visitedCordinate.VisitedHeight, visitedCordinate.VisitedWidth] = 7;
				rottenDayTracker[visitedCordinate.VisitedHeight, visitedCordinate.VisitedWidth] = visitedCordinate.RottenDay;
				Console.WriteLine($"visted height {visitedCordinate.VisitedHeight}, visited width {visitedCordinate.VisitedWidth}");
				totalRottenDay = visitedCordinate.RottenDay;
				Print2DArray<int>(rottenDayTracker);
				for (int i = 0; i < 4; i++)
				{
					var movingDirectionHeight = fourDirections[2 * i];
					var movingDirectionWidth = fourDirections[2 * i + 1];
					var nextVisitHeight = visitedCordinate.VisitedHeight + movingDirectionHeight;
					var nextVisitWidth = visitedCordinate.VisitedWidth + movingDirectionWidth;
					if (nextVisitHeight > -1 && nextVisitWidth > -1 && nextVisitHeight < height && nextVisitWidth < width)
					{
						//Console.WriteLine($"{nextVisitHeight}, {nextVisitWidth}, {visited[nextVisitHeight, nextVisitWidth]}, {grid[nextVisitHeight, nextVisitWidth]}");
						if (nextVisitHeight >= 0 && nextVisitWidth >= 0 && (visited[nextVisitHeight, nextVisitWidth] != 7) && grid[nextVisitHeight][nextVisitWidth] == 1)
						{
							keepTrack.Enqueue(new KeepTrackObject() { VisitedWidth = nextVisitWidth, VisitedHeight = nextVisitHeight, RottenDay = visitedCordinate.RottenDay + 1 });
						}
					}
				}
				Console.WriteLine($"=====VISITED CELLS======{keepTrack.Count()}");
			}
			var totalRottenOrange = CountRottenOrange(visited, height, width);
			Console.WriteLine($"total === {totalGoodOrange} === vs === Rotten Orange === {totalRottenOrange}");
			if(totalGoodOrange - totalRottenOrange > 0)
			{
				return -1;
			}
			else
			{
				return totalRottenDay;
			}
		}

		private static CountingResult CountFreshOrange(int[][] grid, int height, int width)
		{
			int totalGoodOrange = 0;
			var startPoint = new List<int[]> {};
			// Count total good orange number
			for (int heightCount = 0; heightCount < height; heightCount++)
				for (int widthCount = 0; widthCount < width; widthCount++)
					if (grid[heightCount][widthCount] == 1)
						totalGoodOrange++;
					else if(grid[heightCount][widthCount] == 2)
					{
						totalGoodOrange++;
						startPoint.Add(new int[]{ heightCount, widthCount });
					}
			var returnResult = new CountingResult() { TotalGoodOrange = totalGoodOrange, StartPoint = startPoint };
			return returnResult;
		}

		private static int CountRottenOrange(int[,] grid, int height, int width)
		{
			// Count total good orange number
			int totalRottenOrage = 0;
			for (int heightCount = 0; heightCount < height; heightCount++)
				for (int widthCount = 0; widthCount < width; widthCount++)
					if (grid[heightCount,widthCount] > 0)
						totalRottenOrage++;
			// add one because the first orange is rotten but it is shown a zero day in our final met
			return totalRottenOrage;
		}

		public class KeepTrackObject
		{
			public int VisitedHeight { get; set; }
			public int VisitedWidth { get; set; }
			public int RottenDay { get; set; }
		}

		public class CountingResult
		{
			public List<int[]> StartPoint { get; set; }
			public int TotalGoodOrange { get; set; }
		}

		static void PrintJagged(dynamic array)
		{
			if (array.Length == 0)
				return;

			if (array[0].GetType().IsArray)
			{
				foreach (var element in array)
				{
					PrintJagged(element);
				}
			}
			else
			{
				int size = array.Length;
				string str = "[ ";

				for (int i = 0; i < size; i++)
				{
					str += array[i].ToString();

					if (i < size - 1)
						str += ", ";
				}

				str += " ]";

				Console.WriteLine(str);
			}
		}

		public static void Print2DArray<T>(T[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write(matrix[i, j] + "\t");
				}
				Console.WriteLine();
			}
		}
	}
}
