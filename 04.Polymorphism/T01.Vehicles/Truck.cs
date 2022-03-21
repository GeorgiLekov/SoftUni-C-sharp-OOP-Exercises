using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            base.Refuel(fuel);
        }
    }
}
