using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 0.9;
        }
    }
}
