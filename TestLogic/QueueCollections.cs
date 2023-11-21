using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground
{
    public static class QueueCollections
    {
        public static string CountOfAtoms(string formula)
        {
            var atomTracking = new SortedDictionary<string, long>();
            var processQueue = new Stack<MutableTracker>();

            for (int i = 0; i < formula.Length; i++)
            {
                var currentChar = formula[i];
                var isUpper = char.IsUpper(currentChar);
                var isLower = char.IsLower(currentChar);
                var isNumber = char.IsNumber(currentChar);
                var isOpenBracket = currentChar == '(';
                var isCloseBracket = currentChar == ')';
                if (isUpper)
                {
                    var element = new MutableTracker() { AtomName = currentChar.ToString(), AtomCount = 1 };
                    processQueue.Push(element);
                }
                else if (isLower)
                {
                    var prevLetter = processQueue.Pop();
                    prevLetter.AtomName = $"{prevLetter.AtomName}{currentChar}";
                    processQueue.Push(prevLetter);
                }
                else if (isNumber)
                {
                    var numberLength = 1;
                    while (char.IsNumber(formula[i + numberLength]))
                    {
                        numberLength++;
                        if (i + numberLength > formula.Length) { break; }
                    }
                    var parseMutiplier = int.Parse(formula.Substring(i, numberLength));
                    
                    var prevLetter = processQueue.Pop();
                    prevLetter.AtomCount = prevLetter.AtomCount * parseMutiplier;
                    processQueue.Push(prevLetter);
                    i = i + numberLength - 1;
                }
                else if (isOpenBracket)
                {
                    processQueue.Push(new MutableTracker() { AtomName = currentChar.ToString()});
                }
                else if (isCloseBracket)
                {
                    var numberLength = 0;
                    while (char.IsNumber(formula[i + 1 + numberLength]))
                    {
                        numberLength++;
                        if (i + 1 + numberLength >= formula.Length) 
                        { 
                            break; 
                        }
                    }
                    var isInt = int.TryParse(formula.Substring(i + 1, numberLength), out int mutiplier);

                    var mutiplierInt = isInt ? mutiplier : 1;
                    var storeStack = new Stack<MutableTracker>();
                    //var testString = "K4(ON(SO3)2)2";

                    var seekCloseBracket = processQueue.Pop();
                    while(seekCloseBracket.AtomName != "(")
                    {
                        storeStack.Push(seekCloseBracket);
                        seekCloseBracket.AtomCount = seekCloseBracket.AtomCount * mutiplierInt;
                        seekCloseBracket = processQueue.Pop();
                    }

                    while(storeStack.Count > 0)
                    {
                        processQueue.Push(storeStack.Pop());
                    }
                    i = i + numberLength;
                }
                else
                {
                    Console.WriteLine($"what is it ?? {currentChar}");
                }
            }
            while (processQueue.Count > 0)
            {
                var resultAtom = processQueue.Pop();
                if (atomTracking.ContainsKey(resultAtom.AtomName))
                {
                    atomTracking[resultAtom.AtomName] = atomTracking[resultAtom.AtomName] + resultAtom.AtomCount;
                }
                else
                {
                    atomTracking.Add(resultAtom.AtomName, resultAtom.AtomCount);
                }
            };
            var stringBuilder = new StringBuilder();

            foreach (var item in atomTracking)
            {
                stringBuilder.Append(item.Key);
                if(item.Value > 1)
                {
                    stringBuilder.Append(item.Value);
                }
            }
            return stringBuilder.ToString();
        }
    }

    public class MutableTracker
    {
        public string AtomName { get; set; }
        public long AtomCount { get; set; }

    }
}
