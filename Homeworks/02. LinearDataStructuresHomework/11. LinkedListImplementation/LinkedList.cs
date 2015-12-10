namespace _11.LinkedListImplementation
{
    public class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public LinkedList()
        {
            this.FirstElement = null;
        }

        public ListItem<T> FirstElement 
        {
            get
            {
                return this.firstElement;
            }

            set
            {
                this.firstElement = value;
            }
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> item = new ListItem<T>(value);
                item.NextItem = this.FirstElement;
                this.FirstElement = item;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> item = new ListItem<T>(value);
                while (item.NextItem != null)
                {
                    item = item.NextItem;
                }

                item.NextItem = new ListItem<T>(value);
            }
        }

        public void RemoveFirst()
        {
            this.FirstElement = this.FirstElement.NextItem;
        }

        public void RemoveLast()
        {
            ListItem<T> newItem = this.FirstElement;
            while (newItem.NextItem != null)
            {
                newItem = newItem.NextItem;
            }

            newItem.NextItem = null;
        }

        public int Count()
        {
            int counter = 1;
            ListItem<T> newItem = this.FirstElement;

            while (newItem.NextItem != null)
            {
                newItem = newItem.NextItem;
                counter++;
            }

            return counter;
        }
    }
}
