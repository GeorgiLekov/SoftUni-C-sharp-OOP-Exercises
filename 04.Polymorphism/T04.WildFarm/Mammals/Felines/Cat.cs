using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public class Cat : Feline
    {
        private const double fatterPerPoint = 0.3;

        public Cat(string name, double weight, string region, string breed) : base(name,weight,region,breed)
        {
        }

        public override void MakeSound()
        {

            Console.WriteLine($"Meow");
        }
        public override bool CanEat(string foodType)
        {
            string temp = foodType.ToLower();
            if (temp == "vegetable" || temp == "meat")
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
