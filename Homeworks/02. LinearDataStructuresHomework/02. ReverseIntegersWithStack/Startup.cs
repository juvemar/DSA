namespace _02.ReverseIntegersWithStack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    public class Startup
    {
        private static string input = string.Empty;

        public static void Main()
        {
            Console.WriteLine("Please enter a sequence of integers separated by a space:");
            var arr = ReadInput();

            var stack = FillStack(arr);

            ReturnReversedIntegers(stack);
        }

        private static List<int> ReadInput()
        {
            var currentNumber = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            return currentNumber;
        }

        private static Stack<int> FillStack(IEnumerable<int> list)
        {
            Stack<int> stack = new Stack<int>();

            foreach (var number in list)
            {
                stack.Push(number);
            }

            return stack;
        }

        private static void ReturnReversedIntegers(Stack<int> stack)
        {
            Console.WriteLine("\nNumbers in reverse order:");
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
