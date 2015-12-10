namespace PriorityQueueImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Add(10);
            queue.Add(5);
            queue.Add(9);
            queue.Add(3);
            queue.Add(4);
            queue.Add(6);
            queue.Add(12);
            queue.Add(13);
            queue.Add(10);
            queue.Add(5);
            queue.Add(9);
            queue.Add(3);
            queue.Add(4);
            queue.Add(6);
            queue.Add(12);
            queue.Add(13);
            queue.Add(10);
            queue.Add(5);
            queue.Add(9);
            queue.Add(3);
            queue.Add(4);
            queue.Add(6);
            queue.Add(12);
            queue.Add(13);

            foreach (var item in queue)
            {
                Console.WriteLine("Element -> " + queue.Remove());
                Console.WriteLine("Queue's length is: " + queue.Count);
            }

            Console.WriteLine(queue);
        }
    }
}
