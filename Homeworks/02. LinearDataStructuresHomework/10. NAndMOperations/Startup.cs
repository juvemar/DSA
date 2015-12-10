namespace _10.NAndMOperations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int n = 5;
            int m = 20;
            var operationsList = FindTheLessOperations(n, m);

            Console.WriteLine(string.Join(", ", operationsList));
        }

        private static List<string> FindTheLessOperations(int n, int m)
        {
            var operationsList = new List<string>();

            while (n != m)
            {
                if (m % n == 0)
                {
                    n = n * 2;
                    operationsList.Add("\nn * 2" + " - " + n);
                }
                else
                {
                    int residue = m % n;
                    while (m % n != 0)
                    {
                        n = n + 1;
                        operationsList.Add("\nn + 1" + " - " + n);

                        if (m % n != 0)
                        {
                            operationsList.Add("\nn + 2" + " - " + n);
                            n = n + 2;
                        }
                    }
                }
            }

            return operationsList;
        }
    }
}
