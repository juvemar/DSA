namespace _06.RemoveAllOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var resultList = RemoveOddOccurences(numbers);

            PrintResult(resultList);
        }

        private static void PrintResult(List<int> resultList)
        {
            Console.WriteLine(string.Join(", ", resultList));
        }

        private static List<int> RemoveOddOccurences(List<int> numbers)
        {
            var checkedNumbers = new HashSet<int>();

            var currentNumber = numbers[0];
            var currentOccurences = 1;
            var startNextCheck = true;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (startNextCheck)
                {
                    if (!checkedNumbers.Contains(numbers[i]))
                    {
                        currentNumber = numbers[i];
                        startNextCheck = false;
                        checkedNumbers.Add(currentNumber);
                    }
                }
                else
                {
                    if (numbers[i] == currentNumber)
                    {
                        currentOccurences++;
                    }

                    if (i == numbers.Count - 1)
                    {
                        if (currentOccurences % 2 != 0)
                        {
                            numbers.RemoveAll(n => n == currentNumber);
                        }

                        i = -1;
                        currentOccurences = 1;
                        startNextCheck = true;
                    }
                }
            }

            return numbers;
        }
    }
}
