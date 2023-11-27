using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground
{
    public static class TreeTreverse
    {
        public static bool CanJump(int[] stones)
        {
            // we need to unify the index, if the 
            var goalPost = stones.Length;
            for (int i = stones.Length - 2; i >= 0; i--)
            {
                var currentStoneValue = stones[i];
                var canJump = i + currentStoneValue + 1 >= goalPost;
                if (canJump)
                {
                    goalPost = i + 1;
                }
            }

            return goalPost == 1;
        }

        public static bool CanCross(int[] stones)
        {
            //[0,1,3,5,6,8,12,17]
            if((stones[1] - stones[0]) != 1) return false;
            stones = stones.Skip(1).ToArray();
            var goal = stones.Last();
            var nextJumpSteps = new List<int>() { -1, 0, 1 };
            var stoneHash = stones.ToHashSet();
            var dfsStack = new Stack<Tuple<int, int>>();
            var visited = new HashSet<Tuple<int, int>>();

            dfsStack.Push(new Tuple<int, int>(1, 1));

            while (dfsStack.Count > 0)
            {
                var currentPosition = dfsStack.Pop();
                visited.Add(currentPosition);
                foreach ( var jump in nextJumpSteps) 
                {
                    var nextJump = currentPosition.Item2 + jump;
                    // needs to jump forward
                    if (nextJump > 0)
                    {
                        var nextStonePosition = currentPosition.Item1 + nextJump;
                        var nextCoordinates = new Tuple<int, int>(nextStonePosition, nextJump);
                        if (!visited.Contains(nextCoordinates) && stoneHash.Contains(nextStonePosition))
                        {
                            if (nextStonePosition == goal)
                            {
                                return true;
                            }
                            dfsStack.Push(nextCoordinates);
                        }
                    }
                }
            }


            return false;
        }
    }

    public class FrogPathTracker
    {
        public int CurrentPosition { set; get; }
        public int PreviousJump { set; get; }
     }
}
