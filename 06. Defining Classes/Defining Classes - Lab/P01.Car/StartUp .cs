using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Car car1 = new Car();
            car1.Make = "Mercedes";
            car1.Model = "ML";
            car1.Year = 2004;

            Car car2 = new Car()
            {
                Make = "Honda",
                Model = "Jazz",
                Year = 2002
            };

            Console.WriteLine($"Make: {car1.Make}, Model: {car1.Model}, Year: {car1.Year}");
        }
    }
}
