using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic.ContainerWithMostWater
{
    public static class ContainerWithMostWaterClass
    {
        public static int MaxArea(int[] height)
        {
            int area = 0;
            var leftPointer= 0;
            var rightPointer = height.Length - 1;
            for (int leftIndex = 0; leftIndex < height.Length; leftIndex++)
            {
                var leftHeight = height[leftPointer];
                var rightHeight = height[rightPointer];
                if(leftHeight < rightHeight)
                {
                    area = CalculateArea(leftHeight, rightPointer - leftPointer, area);
                    leftPointer++;
                }
                else
                {
                    area = CalculateArea(rightHeight, rightPointer - leftPointer, area);
                    rightPointer--;
                }
            }
            return area;
        }
        private static int CalculateArea(int height, int width, int maxArea)
        {
            var currentArea = height * width;
            maxArea = maxArea > currentArea ? maxArea : currentArea;
            return maxArea;
        }
        private static int SmallerValue(int left, int right)
        {
            return left < right ? left : right;
        }
    }
}
