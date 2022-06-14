using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listTires = new List<Tire[]>();
            List<Engine> listEngines = new List<Engine>();
            List<Car> listCars = new List<Car>();

            string tireInput;
            while ((tireInput = Console.ReadLine()) != "No more tires")
            {
                string[] parts = tireInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire tire1 = new Tire(int.Parse(parts[0]), double.Parse(parts[1]));
                Tire tire2 = new Tire(int.Parse(parts[2]), double.Parse(parts[3]));
                Tire tire3 = new Tire(int.Parse(parts[4]), double.Parse(parts[5]));
                Tire tire4 = new Tire(int.Parse(parts[6]), double.Parse(parts[7]));

                Tire[] tires = new Tire[4];
                tires[0] = tire1;
                tires[1] = tire2;
                tires[2] = tire3;
                tires[3] = tire4;
                listTires.Add(tires);
            }

            string engineInput;
            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] parts = engineInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(parts[0]), double.Parse(parts[1]));
                listEngines.Add(engine);
                
            }

            string carInput;
            while ((carInput = Console.ReadLine()) != "Show special")
            {
               
                string[] carParts = carInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                string make = carParts[0];
                string model = carParts[1];
                int year = int.Parse(carParts[2]);
                double fuelQuantity = double.Parse(carParts[3]);
                double fuelConsumption = double.Parse(carParts[4]);

                int engineIndex = int.Parse(carParts[5]);
                int tiresIndex = int.Parse(carParts[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, listEngines[engineIndex], listTires[tiresIndex]);
                listCars.Add(car);
                
            }

            listCars = listCars.Where(car => car.Year >= 2017)
                               .Where(car => car.Engine.HorsePower > 330)
                               .Where(car => car.Tires[0].Pressure + car.Tires[1].Pressure + car.Tires[2].Pressure + car.Tires[3].Pressure > 9)
                               .Where(car => car.Tires[0].Pressure + car.Tires[1].Pressure + car.Tires[2].Pressure + car.Tires[3].Pressure < 10).ToList();

            DriveSpecialCar(listCars);
            Console.WriteLine(string.Join(Environment.NewLine, listCars));
        }
        
        private static void DriveSpecialCar(List<Car> listCars)
        {
            foreach (Car car in listCars)
            {
                double needFuel = car.FuelConsumption / 100 * 20;
                if (car.FuelQuantity >= needFuel)
                {
                    car.FuelQuantity -= needFuel;
                }
            }
        }
    }
}
