using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehicleExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 0.9;
        }
    }
}
