using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsepower;
        private double fuel;
        private double fuelConsumption;

        public int Horsepower { get{ return horsepower; } set{ horsepower = value; } }
        public double Fuel { get{ return fuel; } set{ fuel = value; } }
        public virtual double FuelConsumption { get{ return fuelConsumption; } set{ fuelConsumption = value; } }

        public Vehicle(int horsepower, double fuel)
        {
            Horsepower = horsepower;
            Fuel = fuel;
            fuelConsumption = 1.25;
        }

        public virtual void Drive(double kilometers)
        {
            /*if(Fuel < kilometers * FuelConsumption && kilometers > 0)
            {
                Fuel -= kilometers * FuelConsumption;
            }*/
            Fuel -= kilometers * FuelConsumption;
        } 
    }
}
