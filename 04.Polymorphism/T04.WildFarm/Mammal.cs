using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public abstract class Mammal : Animal
    {
        
        public string LivingRegion { get; set; }
        public override string ToString()
        {
            string result = $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
            return result;
        }
    }
}
