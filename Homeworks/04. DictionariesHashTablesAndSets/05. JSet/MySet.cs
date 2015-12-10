namespace _05.JSet
{
    using System.Collections.Generic;

    using _04.HashTableImplementation;

    public class MySet<T> : IEnumerable<T>
    {
        private MyHashTable<int, T> elements;

        public MySet()
        {
            this.elements = new MyHashTable<int, T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element.GetHashCode());
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public MySet<T> Intersect(MySet<T> other)
        {
            MySet<T> newSet = new MySet<T>();

            foreach (var element in this)
            {
                foreach (var otherElement in other)
                {
                    if (element.Equals(otherElement))
                    {
                        newSet.Add(element);
                    }
                }
            }

            return newSet;
        }

        public MySet<T> Union(MySet<T> other)
        {
            MySet<T> newSet = new MySet<T>();

            foreach (var element in this)
            {
                newSet.Add(element);
            }

            foreach (var element in other)
            {
                newSet.Add(element);
            }

            return newSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.elements)
            {
                yield return pair.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
