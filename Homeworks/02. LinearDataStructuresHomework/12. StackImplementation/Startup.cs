namespace _12.StackImplementation
{
    using System;
    
    public class Startup
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(4);
            stack.Push(2);
            stack.Push(7);
            stack.Push(8);

            Console.WriteLine("Four items were added:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Stacks initial capacity is: " + stack.Capacity);            
            Console.WriteLine("Stacks count is " + stack.Count);
            Console.WriteLine();

            stack.Push(9);
            Console.WriteLine("A fifth item was added: ");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Stacks capacity already is: " + stack.Capacity);
            Console.WriteLine("Stacks count is " + stack.Count);
            Console.WriteLine();

            stack.Pop();
            Console.WriteLine("Last item removed: ");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Stacks count afted the removal is " + stack.Count);
        }
    }
}
