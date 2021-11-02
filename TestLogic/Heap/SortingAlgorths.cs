using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLogic
{
    public static class SortingAlgorths
    {
        public static int[] BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                // we are looping each element in arr, and put the largest element in the correct place
                for(int j = 0; j < arr.Length - 1 - i ; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        // 0 1 2 3 4 5 6
        // pivot = 7 / 2 = 3 
        public static int[] MergeSort(int[] arr) 
        {
            var pivot = arr.Length / 2;
            // merge left
            RecursiveMerge(ref arr, 0, pivot -1 );
            // merge right 
            RecursiveMerge(ref arr, pivot + 1, arr.Length -1);
            return arr;
        }

        public static int[] RecursiveMerge(ref int[] arr, int startIndex, int endIndex)
        {
            var pivot = arr.Length / 2;
            

            return arr;
        }
        

        public static int FindIndex( int target, int startIndex, int endIndex, List<int> input)
        {
            if (startIndex == endIndex) return startIndex;
            var mediumPoint = (startIndex + endIndex) / 2;
            int result;
            if(input[mediumPoint] < target)
            {
                result = FindIndex(target, mediumPoint, endIndex, input);
            }
            else
            {
                result = FindIndex(target, startIndex, mediumPoint, input);
            }
            return result;
        }
    }
}
