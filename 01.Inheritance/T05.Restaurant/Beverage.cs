using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        double milliliters;

        public double Milliliters { get { return milliliters; } set { milliliters = value; } }

        public Beverage(string name, decimal price, double milliliters)
        {
            Name = name;
            Price = price;
            Milliliters = milliliters;
        }
    }
}
