using System;
using System.Linq;

namespace T01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split().ToArray();

            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine().Split().ToArray();

            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                double kmOrFuel = double.Parse(command[2]);

                switch (command[0])
                {
                    case "Drive":
                        if (command[1] == "Car")
                        {
                            car.Drive(kmOrFuel);
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Drive(kmOrFuel);
                        }
                        break;
                    case "Refuel":
                        if (command[1] == "Car")
                        {
                            car.Refuel(kmOrFuel);
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(kmOrFuel);
                        }
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
