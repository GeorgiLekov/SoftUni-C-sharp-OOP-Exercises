using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Tiger : Feline
    {
        private const double fatterPerPoint = 1.00d;

        public Tiger(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }

        public override void MakeSound()
        {

            Console.WriteLine($"ROAR!!!");
        }
        public override bool CanEat(string foodType)
        {
            string temp = foodType.ToLower();
            if (temp == "meat")
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
