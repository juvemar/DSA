namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var sequence = new List<int> { 1, 2, -3, -2, 10, -8, 4, 6 };
            Console.WriteLine("The initial sequence is: " + string.Join(", ", sequence));

            sequence.RemoveAll(i => i < 0);
            Console.WriteLine("The new sequence is: " + string.Join(", ", sequence));
        }
    }
}
