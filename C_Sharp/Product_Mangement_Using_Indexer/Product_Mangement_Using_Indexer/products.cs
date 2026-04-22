using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Mangement_Using_Indexer
{
    internal class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


        public Products(string  name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

    }
}
