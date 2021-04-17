using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic.ReverseInteger
{
    public class ReverseIntegerClass
    {
        public int ReverseIntegerMethod(int input)
        {
            bool isNegative = input < 0;
            string inputString = Math.Abs(input).ToString();
            var reverseStack = new Stack<char>();
            string outputString = "";
            int result = 0;
            foreach(char c in inputString)
            {
                reverseStack.Push(c);
            }
            while(reverseStack.Count > 0)
            {
                outputString = outputString + reverseStack.Pop();
            }

            try
            {
                result = Int32.Parse(outputString);
            }
            catch(Exception e)
            {
                result = 0;
            }
            return isNegative ? (int)-result : (int)result;
        }
    }
}
