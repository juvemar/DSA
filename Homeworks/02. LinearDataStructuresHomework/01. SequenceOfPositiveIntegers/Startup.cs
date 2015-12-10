namespace _01.SequenceOfPositiveIntegers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static string input = string.Empty;

        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of integers:");
            ReadInput();
            List<int> list = ParseStringToList();

            ReturnSumAndAverage(list);
        }

        private static void ReadInput()
        {
            string currentNumber = Console.ReadLine();

            if (currentNumber == string.Empty)
            {
                return;
            }

            input += " " + currentNumber;

            ReadInput();
        }

        private static List<int> ParseStringToList()
        {
            input = input.Trim();
            var sequence = input.Split(' ').Select(int.Parse).ToList();

            return sequence;
        }

        private static void ReturnSumAndAverage(IEnumerable<int> list)
        {
            double sum = 0;

            foreach (var currentNumber in list)
            {
                sum += currentNumber;
            }

            double average = sum / (list.Count());

            Console.WriteLine("Sum: {0}\nAverage: {1}", sum, average);
        }
    }
}
