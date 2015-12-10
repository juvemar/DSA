namespace _02.Renewal
{
    using System;

    // This is a formula counting the combinations of n elements put on 1 to n places
    // (n elements on 1 place + n elements on 2 places + .. n elements on n places)
    public class CombinationsWithoutRepetitions
    {
        static void Main()
        {
            var combinationsCount = 0;
            var n = 5;

            var things = n;
            for (int j = 1; j < n; j++)
            {
                things = things * j;
            }

            for (int i = n; i > 0; i--)
            {
                var places = i;
                for (int j = 1; j < i; j++)
                {
                    places = places * j;
                }

                var diff = n - i;
                for (int j = 1; j < n - i; j++)
                {
                    diff = diff * j;
                }

                if (diff == 0)
                {
                    diff = 1;
                }

                var combs = things / (places * diff);
                combinationsCount += combs;
            }

            Console.WriteLine(combinationsCount);
        }
    }
}
