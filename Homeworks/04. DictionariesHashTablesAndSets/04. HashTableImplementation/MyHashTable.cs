namespace _04.HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyHashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;
        private const double CapacityBoundary = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] elements;
        private int count;
        private ICollection<K> keys;
        private int elementsCounter;
        private int capacity = InitialCapacity;

        public MyHashTable()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.elementsCounter = 0;
            this.Count = 0;
            this.keys = new HashSet<K>();
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.elements = new LinkedList<KeyValuePair<K, T>>[capacity];
        }

        public K[] Keys
        {
            get
            {
                var listOfKeys = new List<K>(this.count);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys.ToArray();
            }
        }

        public void Add(K key, T value)
        {
            if (this.Count() > (CapacityBoundary) * this.elementsCounter)
            {
                this.Expand();
            }

            this.keys.Add(key);

            var pairToAdd = new KeyValuePair<K, T>(key, value);
            var position = this.GetPosition(key);

            if (this.elements[position] == null)
            {
                this.elements[position] = new LinkedList<KeyValuePair<K, T>>();
                this.elements[position].AddFirst(pairToAdd);

                this.Count++;
            }
            else
            {
                this.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count++;
                }

                this.elements[position].AddLast(pairToAdd);
            }

            this.elementsCounter++;
        }

        private void Expand()
        {
            this.capacity *= 2;
            var newList = new MyHashTable<K, T>();
            newList.capacity = this.capacity;

            foreach (var item in this)
            {
                newList.Add(item.Key, item.Value);
            }

            this.elements = newList.elements;
        }

        public void Remove(K key)
        {
            var position = this.GetPosition(key);

            if (this.Contains(key))
            {
                var pairToRemove = this.elements[position].First(x => x.Key.Equals(key));
                this.elements[position].Remove(pairToRemove);
                this.elementsCounter--;
                this.keys.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count--;
                }
            }
        }

        private int GetPosition(K key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }

        public bool Contains(K key)
        {
            if (key == null)
            {
                return false;
            }

            foreach (var valuesList in this.elements)
            {
                foreach (var value in valuesList)
                {
                    if (value.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var valuesList in this.elements)
            {
                if (valuesList == null)
                {
                    break;
                }

                foreach (var value in valuesList)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
