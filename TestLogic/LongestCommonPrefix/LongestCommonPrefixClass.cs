using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic.LongestCommonPrefix
{
    public static class LongestPrefix
    {
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";

            Stack<char> LongestPrefixStack = new Stack<char>();
            
            foreach(char eachChar in strs[0])
            {
                LongestPrefixStack.Push(eachChar);
            }

            for(int i = 1; i < strs.Length; i++)
            {
                while(LongestPrefixStack.Count > strs[i].Length)
                    LongestPrefixStack.Pop();

                for ( int stringIndex = LongestPrefixStack.Count - 1; stringIndex > -1; stringIndex --)
                {
                    if(LongestPrefixStack.ToArray()[LongestPrefixStack.Count - stringIndex - 1] != strs[i].ToCharArray()[stringIndex])
                    {
                        while (LongestPrefixStack.Count > stringIndex)
                            LongestPrefixStack.Pop();
                    }
                }
            }
            var finalString = "";
            while(LongestPrefixStack.Count > 0)
            {
                finalString = LongestPrefixStack.Pop() + finalString;
            }
            return finalString;
        }

    }
}
