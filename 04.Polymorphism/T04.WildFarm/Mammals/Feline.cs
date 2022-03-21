using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public abstract class  Feline : Mammal 
    {
        public Feline(string name, double weight, string region, string breed)
        {
            Name = name;
            Weight = weight;
            LivingRegion = region;
            Breed = breed;
        }
        public string Breed { get; set; }

        public override string ToString()
        {
            string result = $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
            return result;
        }
    }
}
