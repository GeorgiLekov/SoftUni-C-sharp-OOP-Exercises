using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Hen : Bird
    {
        private const double fatterPerPoint = 0.35;

        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Cluck");
        }

        public override bool CanEat(string foodType)
        {
            return true;
        }

        public override void Eat(int amount)
        {
            double weightToGain = fatterPerPoint * amount;
            Weight += weightToGain;
            FoodEaten += amount;
        }
    }
}
