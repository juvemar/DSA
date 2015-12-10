namespace _02.CollectionOfProducts
{
    using System;

    public class Product : IComparable<Product>
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
            : this()
        {
            this.Name = name;
            this.Price = price;
        }

        public Product()
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public int CompareTo(Product product)
        {
            if (this.Price > product.Price)
            {
                return 1;
            }
            else if (this.Price < product.Price)
            {
                return -1;
            }

            return 0;
        }
    }
}
