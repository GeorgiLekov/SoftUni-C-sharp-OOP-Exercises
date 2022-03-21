using System;
using System.Linq;

namespace T02.VehicleExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            Car car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            input = Console.ReadLine().Split().ToArray();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Truck truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            input = Console.ReadLine().Split().ToArray();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Bus bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

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
                        else if(command[1] == "Bus")
                        {
                            bus.DriveBus(kmOrFuel, command[1]);
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
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(kmOrFuel);
                        }
                        break;

                    case "DriveEmpty":
                        bus.DriveBus(kmOrFuel, command[1]);
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
