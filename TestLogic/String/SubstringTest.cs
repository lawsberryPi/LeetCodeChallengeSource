using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class SubstringTest
    {
        public static int[] countSubarrays(int[] arr) {
            // Write your code here
    
            var resultList = new List<int>();
    
            for(int i = 0; i < arr.Length; i ++)
            { 
                Console.WriteLine($"<<<<<<<{arr[i]}>>>>>>>>");
                int totalSubstring = 1;
      
                if(i == 0)
                {
                    var rightNode = arr[i + 1];
                    var rightIndex = 1;
                    // visit right
                    while(rightNode < arr[i] && rightIndex !=  arr.Length - 1)
                    {

                        totalSubstring ++;
                        rightIndex ++;
                        rightNode = arr[rightIndex];
                        Console.Write($" right traverse{rightNode} ");

                    }
                }
                else if( i == arr.Length - 1)
                {
                    var leftNode = arr[arr.Length -2];
                    var leftIndex = arr.Length -2;
                    while(leftNode < arr[i] && leftIndex != -1 )
                    {
                        totalSubstring ++;
                        leftIndex --;
                        leftNode = arr[leftIndex];
                        Console.Write($" left traverse{leftNode} ");

                    }
                }
                else
                {
                    int rightNode = arr[i + 1];
                    int leftNode = arr[i - 1];
                    int leftIndex = i;
                    int rightIndex = i;
                    while(arr[i - 1] < arr[i] && leftIndex != 0 )
                    {
                        totalSubstring ++;
                        leftIndex --;
                        leftNode = arr[leftIndex];
                        Console.Write($" left traverse{leftNode} ");

                    }
                    while(arr[i+1] < arr[i] && rightIndex !=  arr.Length)
                    {

                        totalSubstring ++;
                        rightIndex ++;
                        rightNode = arr[rightIndex];
                        Console.Write($" right traverse{rightNode} ");

                    }
        
                }
         
                // visit to the left 

      

                Console.WriteLine("<<<<<<<<<<<<<<< >>>>>>>>>>>>>");
                resultList.Add(totalSubstring);
            }    
            return resultList.ToArray();
        }    }
}