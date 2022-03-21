using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.BirthdayCelebration
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdays = new List<IBirthable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split().ToArray();

                switch (input[0])
                {
                    case "Citizen":
                        string name = input[1];
                        int age = int.Parse(input[2]);
                        string ID = input[3];
                        string birthday = input[4];

                        birthdays.Add(new Human(name, age, ID, birthday));
                        break;

                    case "Pet":
                        string namePet = input[1];
                        string birthdayPet = input[2];

                        birthdays.Add(new Pet(namePet, birthdayPet));
                        break;
                }
                command = Console.ReadLine();
            }
            string year = Console.ReadLine();

            foreach (var entity in birthdays)
            {
                string[] current = entity.birthday.Split('/', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (current[2] == year)
                {
                    Console.WriteLine(entity.birthday);
                }
            }
        }
    }
}
