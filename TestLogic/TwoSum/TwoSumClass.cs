using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLogic.TwoSum
{
    public static class TwoSumClass
    {
        public static int[] TwoSumMethod(int[] nums, int target)
        {
            Dictionary<int, int> numberKeepTrack = new Dictionary<int, int>() { };

            for (int leftPointer = 0; leftPointer < nums.Length; leftPointer++)
            {
                if (numberKeepTrack.ContainsValue(target - nums[leftPointer]))
                {
                    var key = numberKeepTrack.FirstOrDefault(x => x.Value == target - nums[leftPointer]).Key;
                    return new int[] { leftPointer, key};
                }

                numberKeepTrack.Add(leftPointer, nums[leftPointer]);
            }
            return nums;
        }
    }
}
