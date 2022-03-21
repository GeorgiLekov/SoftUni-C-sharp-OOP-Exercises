using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        string name;
        decimal price;

        public string Name { get { return name; } set{ name = value; } }
        public decimal Price { get { return price; } set{ price = value; } }

    }
}
