using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                switch (input.Length) 
                {
                    case 3:
                        buyers.Add(input[0], new Rebel(input[0], input[1]));
                        break;
                    case 4:
                        buyers.Add(input[0], new Human(input[0], int.Parse(input[1]), input[2], input[3]));
                        break;
                }
            }

            string buyer = Console.ReadLine();

            while (buyer != "End")
            {
                if (buyers.ContainsKey(buyer))
                {
                    buyers[buyer].AddFood();
                }
                buyer = Console.ReadLine();
            }

            int totalFood = 0;

            foreach(var entity in buyers)
            {
                totalFood += entity.Value.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
