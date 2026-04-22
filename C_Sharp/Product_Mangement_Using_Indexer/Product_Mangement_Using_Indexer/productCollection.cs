using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Mangement_Using_Indexer
{
    internal class ProductCollection
    {
        private List<Products> products = new List<Products>();

        public void AddProduct(Products product)
        {
            products.Add(product);
        }

        public Products this[int index]
        {
            get
            {
                return products[index];
            }

            set
            {
                products[index] = value;
            }
        }
        
    }
}
