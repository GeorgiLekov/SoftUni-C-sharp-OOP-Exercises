using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingsize)
        {
            Name = name;
            Weight = weight;
            WingSize = wingsize;
        }
        public double WingSize { get; set; }

        public override string ToString()
        {
            string result = $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
            return result;
        }
    }
}
