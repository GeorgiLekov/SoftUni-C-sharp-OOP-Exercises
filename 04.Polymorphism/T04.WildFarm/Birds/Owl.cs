using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Owl : Bird
    {
        private double fatterPerPoint = 0.25;

        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
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
