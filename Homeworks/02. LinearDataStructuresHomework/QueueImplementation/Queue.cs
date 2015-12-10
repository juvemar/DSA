namespace _13.QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IEnumerable
    {
        LinkedList<T> items;

        public Queue()
        {
            this.items = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Enqueue(T value)
        {
            this.items.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("Queue is empty!");
            }

            T valueToReturn = this.items.First.Value;
            this.items.Remove(valueToReturn);

            return valueToReturn;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("Queue is empty!");
            }

            T valueToReturn = this.items.First.Value;

            return valueToReturn;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
