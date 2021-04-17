using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLogic.ThreeSum
{
    public static class ThreeSumClass
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var sumResult = new List<IList<int>>();
            if (nums.Length < 3) return sumResult;
            if (nums.Length == 3 && nums[0] + nums[1] + nums[2] == 0)
            {
                sumResult.Add(new List<int>() { nums[0], nums[1], nums[2] });
                return sumResult;
            }
            Array.Sort(nums);
            Console.WriteLine(nums);
            int preRightIndex = 0;
            int preMiddleIndex = 0;
            int preLeftIndex = 0;
            int iteratorIndex = 0;
            for (int leftIndex = 0; leftIndex < nums.Length; leftIndex++)
            {
                for(int middleIndex = leftIndex + 1; middleIndex < nums.Length; middleIndex++)
                {
                    for (int rightIndex = middleIndex + 1; rightIndex < nums.Length; rightIndex++)
                    {
                        if(nums[leftIndex] + nums[middleIndex] + nums[rightIndex] == 0)
                        {
                            Console.WriteLine($"({nums[leftIndex]} != {nums[preLeftIndex]}) && ({nums[middleIndex]} != {nums[preMiddleIndex]}) && ({nums[rightIndex]} != {nums[preRightIndex]}) || {iteratorIndex} == 0");

                            if (!((nums[leftIndex] == nums[preLeftIndex]) && (nums[middleIndex] == nums[preMiddleIndex]) && (nums[rightIndex] == nums[preRightIndex])) || iteratorIndex == 0)
                            {
                                sumResult.Add(new List<int>() { nums[leftIndex], nums[middleIndex], nums[rightIndex]});
                                iteratorIndex++;
                            }
                            preRightIndex = rightIndex;
                            preMiddleIndex = middleIndex;
                            preLeftIndex = leftIndex;
                        }
                    }
                }
            }
            return sumResult;
        }
    }
}
