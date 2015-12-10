namespace _09.PrintFifyMemberForN
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = 2;

            var list = FillListWithNumbers(n);

            Console.WriteLine(string.Join(", ", list.GetRange(0, 50)));
        }

        private static List<int> FillListWithNumbers(int n)
        {
            var list = new List<int>();
            var queue = new Queue();

            list.Add(n);
            queue.Enqueue(n);

            for (int i = 0; i < list.Count; i++)
            {
                list.Add((int)queue.Peek() + 1);
                list.Add((int)queue.Peek() * 2 + 1);
                list.Add((int)queue.Dequeue() + 2);

                if (list.Count > 49)
                {
                    break;
                }

                queue.Enqueue(list[i]);
            }

            return list;
        }
    }
}
