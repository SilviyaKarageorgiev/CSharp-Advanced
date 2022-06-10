using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuel = double.Parse(input[1]);
                double fuelCons = double.Parse(input[2]);

                if (!set.Contains(model))
                {
                    set.Add(model);

                    Car car = new Car();
                    car.Model = model;
                    car.FuelAmount = fuel;
                    car.FuelConsumptionPerKilometer = fuelCons;

                    cars.Add(car);
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string command = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string model = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                double distance = int.Parse(cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                if (command == "Drive" && set.Contains(model))
                {
                    Car currCar = cars.Find(c => c.Model == model);
                    currCar = currCar.MovingCar(currCar, distance);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
}
