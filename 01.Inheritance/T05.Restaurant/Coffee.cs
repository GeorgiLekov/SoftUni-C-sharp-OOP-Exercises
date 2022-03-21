using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        
        double caffeine;
        public double Caffeine  { get { return caffeine; } set{ caffeine = value;} }
        public Coffee (string name,double caffeine) : base(name, 3.50m, 50d)
        {
            Caffeine = caffeine;
        }
        public Coffee (string name, decimal price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }
    }
}
