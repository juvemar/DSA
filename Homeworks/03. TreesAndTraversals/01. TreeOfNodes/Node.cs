namespace _01.TreeOfNodes
{
    using System.Collections.Generic;

    public class Node<T>
    {
        private List<Node<T>> children;
        private Node<T> parent;

        public Node()
        {
            this.children = new List<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.HasParent = true;
                this.parent = value;
            }
        }

        public bool HasParent { get; set; }

        public void AddChild(Node<T> node)
        {
            node.Parent = this;
            this.children.Add(node);
        }

        public List<Node<T>> Children
        {
            get
            {
                return this.children;
            }

            private set
            {
                this.children = value;
            }
        }
    }
}
