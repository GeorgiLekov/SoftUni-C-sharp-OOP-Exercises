using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string region)
        {
            Name = name;
            Weight = weight;
            LivingRegion = region;
        }
        private double fatterPerPoint = 0.40;
        public override void MakeSound()
        {

            Console.WriteLine("Woof");
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
