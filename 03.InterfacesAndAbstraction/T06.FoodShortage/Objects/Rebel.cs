using System;
using System.Collections.Generic;
using System.Text;

namespace T06.FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, string organisation)
        {
            Name = name;
            RebelGroup = organisation;
        }
        public string Name { get; set; }
        public string RebelGroup { get; set; }
        public int Food { get; set; }

        public void AddFood()
        {
            Food += 5;
        }
    }
}
