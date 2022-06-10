using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {

        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;

        public string Model 
        { 
            get { return model; } 
            set { model = value; } 
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance { get; set; } = 0;

        public Car MovingCar(Car car, double distance)
        {
            if (distance * car.FuelConsumptionPerKilometer <= car.FuelAmount)
            {
                car.FuelAmount -= distance * car.FuelConsumptionPerKilometer;
                car.TravelledDistance += distance;                
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            return car;
        }

    }
}
