using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Mouse : Mammal 
    {
        public Mouse(string name, double weight, string region)
        {
            Name = name;
            Weight = weight;
            LivingRegion = region;
        }

        private double fatterPerPoint = 0.1;
        public override void MakeSound()
        {
            Console.WriteLine($"Squeak");
        }
        public override bool CanEat(string foodType)
        {
            string temp = foodType.ToLower();
            if(temp == "vegetable"|| temp == "fruit")
            {
                return true;
            }
            Console.WriteLine($"{GetType().Name} does not eat {foodType}!");
            return false;
        }
        public override void Eat(int amount)
        {
            double weightToGain = fatterPerPoint * amount;
            Weight += weightToGain;
            FoodEaten += amount;
        }
    }
}
