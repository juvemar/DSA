namespace _04.RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        private static HashSet<string> forbiddenNumbers;

        public static void Main()
        {
            var initialNumberConst = Console.ReadLine().Select(c => c - '0').ToArray();
            var finalNumber = Console.ReadLine().Select(c => c - '0').ToArray();
            var forbiddenNumbersCount = int.Parse(Console.ReadLine());
            forbiddenNumbers = new HashSet<string>();

            var linked = new LinkedList<string>();

            for (int i = 0; i < forbiddenNumbersCount; i++)
            {
                forbiddenNumbers.Add(Console.ReadLine());
            }

            var initialNumber = (int[])initialNumberConst.Clone();

            //var isInvalidInitialNumber = false;
            //for (int i = 0; i < initialNumber.Length; i++)
            //{
            //    var currentInitialDigit = initialNumber[i];
            //    initialNumber[i] = (currentInitialDigit + 1) % 10;
            //    if (!NumberIsForbidden(initialNumber))
            //    {
            //        isInvalidInitialNumber = true;
            //        break;
            //    }
            //    initialNumber[i] = currentInitialDigit;
            //}

            //if (!isInvalidInitialNumber)
            //{
            //    for (int i = 0; i < initialNumber.Length; i++)
            //    {
            //        var currentInitialDigit = initialNumber[i];
            //        initialNumber[i] = (currentInitialDigit - 1 + 10) % 10;
            //        if (!NumberIsForbidden(initialNumber))
            //        {
            //            isInvalidInitialNumber = true;
            //            break;
            //        }
            //        initialNumber[i] = currentInitialDigit;
            //    }
            //}

            //if (!isInvalidInitialNumber)
            //{
            //    Console.WriteLine(-1);
            //    return;
            //}

            //initialNumber = (int[])initialNumberConst.Clone();
            var stepsCount = 0;
            //while (!NumbersAreEqual(initialNumber, finalNumber))
            {
                for (int i = 0; i < initialNumber.Length; i++)
                {
                    var currentInitialDigit = initialNumber[i];
                    var currentFinalDigit = finalNumber[i];

                    stepsCount += Math.Min(Math.Abs(currentInitialDigit - currentFinalDigit), 10 - Math.Abs(currentInitialDigit - currentFinalDigit));
                }
            }

            Console.WriteLine(stepsCount);
        }

        private static bool NumberIsForbidden(int[] initialNumber)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < initialNumber.Length; i++)
            {
                builder.Append(initialNumber[i]);
            }

            if (forbiddenNumbers.Contains(builder.ToString()))
            {
                return true;
            }

            return false;
        }

        private static bool NumbersAreEqual(int[] initialNumber, int[] finalNumber)
        {
            for (int i = 0; i < initialNumber.Length; i++)
            {
                if (initialNumber[i] != finalNumber[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
