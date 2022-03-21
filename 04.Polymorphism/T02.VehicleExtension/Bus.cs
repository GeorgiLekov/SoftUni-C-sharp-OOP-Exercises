using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehicleExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public void DriveBus(double km, string command)
        {
            double currentFuelConsumption = FuelConsumption;
            if (command != "DriveEmpty")
            {
                currentFuelConsumption += 1.4;
            }

            double fuelPrice = currentFuelConsumption * km;

            if (fuelPrice < FuelQuantity)
            {
                FuelQuantity = -(fuelPrice);
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
