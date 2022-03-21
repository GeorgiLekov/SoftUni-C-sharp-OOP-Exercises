using System;
using System.Collections.Generic;
using System.Text;

namespace T06.FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public void AddFood();
    }
}
