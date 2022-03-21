using System;
using System.Linq;

namespace T04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string[] input = Console.ReadLine().Split().ToArray();
                Pizza pizza = new Pizza(input[1]);

                input = Console.ReadLine().Split().ToArray();
                Dough dough = new Dough(input[1], input[2], decimal.Parse(input[3]));
                pizza.Dough = dough;

                input = Console.ReadLine().Split().ToArray();

                while (input[0] != "END")
                {
                    Topping topping1 = new Topping(input[1], decimal.Parse(input[2]));
                    pizza.AddTopping(topping1);
                    input = Console.ReadLine().Split().ToArray();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
