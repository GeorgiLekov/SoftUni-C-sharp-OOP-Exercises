using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehicleExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double fuel)
        {
            double currentFuel = 0.95 * fuel;
            if (currentFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (currentFuel + FuelQuantity <= TankCapacity)
            {
                FuelQuantity = currentFuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel:F0} fuel in the tank");
            }
        }
    }
}
