namespace PriorityQueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable
    {
        const int InitialCapacity = 16;

        private T[] heap;
        private int index;
        private int capacity = InitialCapacity;

        public PriorityQueue()
        {
            this.heap = new T[capacity];
            this.index = 0;
        }

        public void Add(T element)
        {
            this.CheckIfToExpand();

            this.heap[index] = element;

            var childIndex = this.index;
            var parentIndex = (childIndex - 1) / 2;

            while (parentIndex >= 0 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapElement = this.heap[childIndex];
                this.heap[childIndex] = this.heap[parentIndex];
                this.heap[parentIndex] = swapElement;

                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }

            index++;
        }

        private void CheckIfToExpand()
        {
            if (this.index == this.capacity - 1)
            {
                this.ExpandCapacity();
            }
        }

        private void ExpandCapacity()
        {
            this.capacity *= 2;
            var newList = new T[this.capacity];

            for (int i = 0; i < this.index; i++)
            {
                newList[i] = this.heap[i];
            }

            this.heap = newList;
        }

        private void RecreatArray()
        {
            var newList = new T[this.capacity];

            for (int i = 0; i < this.index; i++)
            {
                newList[i] = this.heap[i];
            }

            this.heap = newList;
        }

        public T Remove()
        {
            var root = this.heap[0];

            if (this.index == 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove element from empty queue!");
            }

            this.heap[0] = this.heap[this.index - 1];
            var parentIndex = 0;

            while (true)
            {
                var leftChildIndex = 2 * parentIndex + 1;
                var rightChildIndex = 2 * parentIndex + 2;

                int minElementIndex;

                if (leftChildIndex > this.index - 1 && rightChildIndex > this.index - 1)
                {
                    break;
                }
                else if (leftChildIndex > this.index - 1)
                {
                    minElementIndex = rightChildIndex;
                }
                else if (rightChildIndex > this.index - 1)
                {
                    minElementIndex = leftChildIndex;
                }
                else
                {
                    minElementIndex = this.heap[rightChildIndex].CompareTo(this.heap[leftChildIndex]) < 0 ? rightChildIndex : leftChildIndex;
                }

                if (this.heap[parentIndex].CompareTo(this.heap[minElementIndex]) < 0)
                {
                    break;
                }

                T swap = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[minElementIndex];
                this.heap[minElementIndex] = swap;
                parentIndex = minElementIndex;
            }

            this.index--;
            return root;
        }

        public T Peek()
        {
            return this.heap[0];
        }

        public int Count
        {
            get
            {
                return this.index;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElementsCount = index;
            var counter = 0;

            foreach (var value in this.heap)
            {
                if (counter == currentElementsCount)
                {
                    break;
                }

                yield return value;
                counter++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.index; i++)
            {
                result.Append(this.heap[i] + " ");
            }

            return result.ToString().Trim();
        }
    }
}
