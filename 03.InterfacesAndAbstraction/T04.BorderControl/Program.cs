using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> schindlersList = new List<IIdentifiable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split().ToArray();
                switch (input.Length)
                {
                    case 3:
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        string ID = input[2];
                        Human human = new Human(name,age,ID);

                        schindlersList.Add(human);
                        break;

                    case 2:
                        string model = input[0];
                        string robotID = input[1];

                        schindlersList.Add(new Robot(model, robotID));
                        break;
                }
                command = Console.ReadLine();
            }

            List<IIdentifiable> result = new List<IIdentifiable>();
            string combination = Console.ReadLine();

            foreach(var entity in schindlersList)
            {
                if (entity.ID.EndsWith(combination))
                {
                    result.Add(entity);
                }
            }

            foreach(var poorFella in result)
            {
                Console.WriteLine(poorFella.ID);
            }
        }
    }
}
