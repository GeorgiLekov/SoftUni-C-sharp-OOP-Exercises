using System;
using System.Collections.Generic;
using System.Text;

namespace T05.BirthdayCelebration
{
    public class Human : IIdentifiable, IBirthable
    {
        public Human(string name, int age, string ID, string birthday)
        {
            Name = name;
            Age = age;
            this.ID = ID;
            this.birthday = birthday;
        }
        public string ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string birthday { get; set; }
    }
}
