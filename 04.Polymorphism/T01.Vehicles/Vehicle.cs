using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public void Drive(double km)
        {
            double fuelPrice = FuelConsumption * km;

            if (fuelPrice < FuelQuantity)
            {
                FuelQuantity -= fuelPrice;
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
