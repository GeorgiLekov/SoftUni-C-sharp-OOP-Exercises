using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehicleExtension
{
    public abstract class Vehicle
    {
        protected double _fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;

            if (fuelQuantity > TankCapacity || fuelQuantity < 0)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity 
        {
            get { return _fuelQuantity; }
            set 
            {
                if (value + _fuelQuantity <= TankCapacity)
                {
                    _fuelQuantity += value;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {value:F0} fuel in the tank");
                }
            } 
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            FuelQuantity = fuel;
        }

        public virtual void Drive(double km)
        {
            double fuelPrice = FuelConsumption * km;

            if (fuelPrice < FuelQuantity)
            {
                FuelQuantity = -fuelPrice;
                Console.WriteLine($"{this.GetType().Name} travelled {km} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
