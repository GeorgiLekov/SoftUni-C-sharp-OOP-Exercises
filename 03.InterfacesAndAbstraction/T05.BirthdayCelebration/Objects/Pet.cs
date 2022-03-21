using System;
using System.Collections.Generic;
using System.Text;

namespace T05.BirthdayCelebration
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            this.birthday = birthday;
        }
        public string Name { get; set; }
        public string birthday { get; set; }
    }
}
