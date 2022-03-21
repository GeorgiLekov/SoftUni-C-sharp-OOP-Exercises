using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, decimal> caloriesPerType = new Dictionary<string, decimal>();
        private decimal caloriesPerGram;
        private decimal weight;

        private Topping()
        {
            caloriesPerType.Add("meat", 1.2m);
            caloriesPerType.Add("veggies", 0.8m);
            caloriesPerType.Add("cheese", 1.1m);
            caloriesPerType.Add("sauce", 0.9m);
            caloriesPerGram = 2m;
        }
        internal Topping(string type, decimal weight):this()
        {
            string temp = type.ToLower();
            if (caloriesPerType.ContainsKey(temp))
            {
                caloriesPerGram *= caloriesPerType[temp];
            }
            else
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            if (weight < 1 || weight > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            this.weight = weight;
        }

        public decimal CaloriesPerGram 
        { 
            get 
            { 
                return caloriesPerGram * weight; 
            }
        }


    }
}
