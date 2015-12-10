namespace _04.FindSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of integers separated by a space:");
            var list = ReadInput();

            var resultList = FindLongestSequenceOfEqualNumbers(list);
            PrintResult(resultList);
        }

        private static IList<int> ReadInput()
        {
            var currentNumber = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            return currentNumber;
        }

        private static List<int> FindLongestSequenceOfEqualNumbers(IList<int> list)
        {
            var indexFirstNumber = 0;
            var maxSequenceLength = 1;
            var currentSequenceLength = 1;
            bool sequenceFound = false;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    if (!sequenceFound)
                    {
                        sequenceFound = true;
                    }

                    currentSequenceLength++;
                    if (maxSequenceLength < currentSequenceLength)
                    {
                        maxSequenceLength = currentSequenceLength;
                        indexFirstNumber = i - maxSequenceLength + 2;
                    }
                }
                else
                {
                    sequenceFound = false;
                    currentSequenceLength = 1;
                }
            }

            var resultList = new List<int>();
            for (int i = indexFirstNumber; i < indexFirstNumber + maxSequenceLength; i++)
            {
                resultList.Add(list[i]);
            }

            return resultList;
        }

        private static void PrintResult(List<int> resultList)
        {
            Console.WriteLine("Longest sequence of equal numbers is: " + string.Join(", ", resultList));
        }
    }
}
