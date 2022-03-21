using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;
        private decimal caloriesPerGram;

        private Dictionary<string, decimal> caloriesPerType = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> caloriesPerFlour = new Dictionary<string, decimal>();
        
        private Dough()
        {

            caloriesPerFlour.Add("white", 1.5m);
            caloriesPerFlour.Add("wholegrain", 1.0m);

            caloriesPerType.Add("crispy", 0.9m);
            caloriesPerType.Add("chewy", 1.1m);
            caloriesPerType.Add("homemade", 1.0m);

            caloriesPerGram = 2m;
        }
        internal Dough(string flourType, string bakingTechnique, decimal weight) : this()
        {
            if (ValidateFlour(flourType))
            {
                this.flourType = flourType;
                string tempFlour = flourType.ToLower();
                caloriesPerGram *= caloriesPerFlour[tempFlour];
            }
            if (ValidateTypes(bakingTechnique))
            {
                this.bakingTechnique = bakingTechnique;
                string tempBaking = bakingTechnique.ToLower();
                caloriesPerGram *= caloriesPerType[tempBaking];
            }
            if (weight<1 || weight>200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            else
            {
                this.weight = weight;
            }
        }

        private bool ValidateFlour(string flourType)
        {
            string temp = flourType.ToLower();
            if (caloriesPerFlour.ContainsKey(temp))
            {
                return true;
            }
            throw new ArgumentException("Invalid type of dough.");
        }

        private bool ValidateTypes(string name)
        {
            string temp = name.ToLower();
            if (caloriesPerType.ContainsKey(temp))
            {
                return true;
            }
            throw new ArgumentException("Invalid type of dough.");
        }

        public decimal CaloriesPerGram
        {
            get
            {
                return caloriesPerGram* weight;
            }
        }
    }
}
