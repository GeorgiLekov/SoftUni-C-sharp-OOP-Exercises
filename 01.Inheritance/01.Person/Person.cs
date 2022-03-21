using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private string name;

        private int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Name: {name}, Age: {age}");

            return stringBuilder.ToString();
        }


    }
}
