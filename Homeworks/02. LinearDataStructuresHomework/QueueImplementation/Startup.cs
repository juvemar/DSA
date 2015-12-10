namespace _13.QueueImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(9);

            Console.WriteLine("Queue's length is " + queue.Count);

            Console.WriteLine("Queue's first item is " + queue.Peek());

            queue.Dequeue();

            Console.WriteLine("Queue's length after removing the first item is " + queue.Count);

            foreach (var item in queue)
            {
                Console.WriteLine("Item's value is {0}", item);
            }
        }
    }
}
