using System;
using System.Collections.Generic;
using System.Text;

namespace T04.BorderControl
{
    public class Human : IIdentifiable
    {
        public Human(string name, int age, string ID)
        {
            Name = name;
            Age = age;
            this.ID = ID;
        }
        public string ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
