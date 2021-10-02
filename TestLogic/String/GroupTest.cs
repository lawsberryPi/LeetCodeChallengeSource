using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class GroupTest
    {

        public static long CountTripletsDicApproach(List<long> arr, long r)
        {
            long totalNumber = 0;
            // target number => index => counted times. 
            Dictionary<long, Dictionary<int, int>> arrProfile = new Dictionary<long, Dictionary<int, int>>();
            for(int i = 0; i < arr.Count; i ++)
            {
                var eachElement = arr[i];
                // 
                if (eachElement % r == 0 && eachElement % (r * r) == 0)
                {
                    bool hasProgression =
                         arrProfile.ContainsKey(eachElement / r) && arrProfile.ContainsKey(eachElement / (r * r));

                    if (hasProgression)
                    {
                        var firstIndices = arrProfile[eachElement / (r * r)];
                        foreach (var firstIndexPair in firstIndices)
                        {
                            var firstIndex = firstIndexPair.Key;
                            var possibleSecondIndices = arrProfile[eachElement / (r * r)].Keys.Where(x => x > firstIndex);
                            totalNumber += possibleSecondIndices.Count();
                        }
                    }
                }
                if (arrProfile.ContainsKey(eachElement))
                {
                    var indexCount = arrProfile[eachElement];
                        
                }
                else
                {
                    arrProfile.Add(eachElement, new Dictionary<int, int>());
                }
            }

            foreach (var eachKey in arrProfile.Keys)
            {
                if (arrProfile.ContainsKey(eachKey * r) && arrProfile.ContainsKey(eachKey * r * r))
                {
                    var currentIndexes = arrProfile[eachKey];
                    var secondLayer = arrProfile[eachKey * r];
                    var thirdLayer = arrProfile[eachKey * r * r];
                    totalNumber = 1;
                }
            }
            //                                  2325652489
            return totalNumber;
        }
        
        public static int[] findMedian(int[] arr) {
            var sortedList = new List<int>(){arr[0]};
            var resultList = new List<int>();
            resultList.Add(arr[0]);
            if(arr.Length > 1) 
            {
                resultList.Add((arr[1] + arr[2])/2);
                sortedList.Add(arr[1]);
            };
    
    
            for(int i = 2; i < arr.Length; i ++)
            {
                sortedList.Add(arr[i]);
                sortedList.Sort();
                if(i % 2 == 0)
                {
                    var oddMedian = (sortedList[i /2] + sortedList[i/2 + 1])/2;
                    resultList.Add(oddMedian);
//        Console.WriteLine($"Lower Index {sortedList[i /2]}, Higher Index {sortedList[i /2 + 1]}";
                }
                else
                {
                    resultList.Add(sortedList[i /2]);
                    //       Console.WriteLine($"only Index {sortedList[i /2]}}";
                }

            }
            // Write your code here
            return resultList.ToArray();
        }
        
        public static long countTriplets(List<long> arr, long r) {
            var nonDuplicatedElement = arr.ToHashSet().OrderBy( a => a).ToList();
            Console.WriteLine(String.Join(", ", nonDuplicatedElement));
            long totalNumber = 0;
            if( r == 1){
                foreach (var eachElement in nonDuplicatedElement)
                {
                    var occurance = (long)arr.Count(x => x == eachElement);
                    totalNumber += ((occurance) * (occurance - 1) * (occurance - 2)) / 6;
                }
                return totalNumber;
            }
            for(int startIndex = 0; startIndex < nonDuplicatedElement.Count() - 2; startIndex ++)
            {
                long startPoint = nonDuplicatedElement[startIndex];
                long secondPoint = startPoint * r;
                long thirdPoint = secondPoint * r;
                long occurrenceOfStartPoint = arr.Count( s => s == startPoint);
                long occurrenceOfSecondPoint = arr.Count( s => s == secondPoint);
                long occurrenceOfThirdPoint = arr.Count( t => t == thirdPoint);
                totalNumber += occurrenceOfStartPoint*occurrenceOfSecondPoint*occurrenceOfThirdPoint;
                Console.WriteLine($"{startPoint} {secondPoint} {thirdPoint}, {occurrenceOfStartPoint} {occurrenceOfSecondPoint} {occurrenceOfThirdPoint}, {totalNumber}");
            }
            return totalNumber;
        }
        public static void GroupByTest(string s)
        { 
            var allSubstrings = new List<char[]>();
            for (int i=0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                {
                    allSubstrings.Add(s.Substring(i, j - i + 1).ToCharArray());
                }
            
            
            
            // key selector which indicates which criterial 
            // Query Selector  Func<TSource,TKey>
            // TSource is the type of the elements of source
            // TKey is the type of the key returned by 

            var afterGroup = allSubstrings.GroupBy(o => o, new AnagramComparer())
                .ToDictionary(x => x.Key,  y => y.Count());

            int totalAmount = 0;
            foreach (var eachValue in afterGroup.Values)
            {
                for (int i = 0; i < eachValue; i++)
                {
                    totalAmount += i;
                }
            }

            Console.WriteLine(totalAmount);
        }
    }
    
    class AnagramComparer : IEqualityComparer<char[]>
    {
        public bool Equals(char[] x, char[] y)
        {
            var trackChar = x.GroupBy(alphabet => alphabet)
                .ToDictionary(x => x.Key,  y => y.Count());

            foreach (var eachChar in y)
            {
                if (trackChar.ContainsKey(eachChar))
                {
                    trackChar[eachChar] = trackChar[eachChar] - 1;
                }
            }
            return trackChar.Values.All(x => x == 0);        }

        public int GetHashCode(char[] obj)
        {
            var hashCode = obj.Sum(x => x.GetHashCode());
            return hashCode;
        }
    }
}