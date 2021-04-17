using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic.CanJump
{
    public static class CanJumpClass
    {
        public static bool CanJump(int[] nums)
        {
            var goalPost = nums.Length - 1;
            for (int i = nums.Length - 1; i > -1; i--)
            {
                if (i + nums[i] >= goalPost)
                    goalPost = i;
            }
            return goalPost == 0;
        }
    }
}
