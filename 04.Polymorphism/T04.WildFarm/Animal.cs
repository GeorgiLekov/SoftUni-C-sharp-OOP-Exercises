using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public virtual void MakeSound()
        {
           
        }

        public virtual bool CanEat(string foodType)
        {
            return false;
        }

        public virtual void Eat(int amount)
        {

        }
    }
}
