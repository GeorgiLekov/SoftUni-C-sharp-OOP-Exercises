using System;
using System.Collections.Generic;
using System.Text;

namespace T03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        List<Product> bag;

        public Person()
        {

        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Bag 
        {
            get
            {
                return bag;
            }
        }

        public int Count 
        { 
            get 
            { 
                return bag.Count; 
            } 
        }
        public void AddBag(Product product)
        {
            bag.Add(product);
        }
    }
}
