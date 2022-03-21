using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        double grams;

        public double Grams { get { return grams; } set { grams = value; } }

        public Food(string name, decimal price, double grams)
        {
            Name = name;
            Price = price;
            Grams = grams;
        }
    }
}
