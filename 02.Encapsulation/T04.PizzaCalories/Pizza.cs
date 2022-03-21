using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings = new List<Topping>();
        private Dough dough;
        private decimal totalCalories;

        public Pizza(string name)
        {
            Name = name;
        }
        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public int NumberOfToppings { get { return toppings.Count; } }

        public decimal TotalCalories 
        { 
            get 
            {
                totalCalories += dough.CaloriesPerGram;
                foreach(var topping in toppings)
                {
                    totalCalories += topping.CaloriesPerGram;
                }
                return totalCalories; 
            } 
        }

        public Dough Dough {  set { dough = value; } }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
    }
}
