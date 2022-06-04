using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            Car car = new Car();
            car.Make = "Mercedes";
            car.Model = "GLS";
            car.Year = 2022;
            car.FuelQuantity = 80;
            car.FuelConsumption = 0.8;

            double distance = 20;

            car.Drive(distance);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
