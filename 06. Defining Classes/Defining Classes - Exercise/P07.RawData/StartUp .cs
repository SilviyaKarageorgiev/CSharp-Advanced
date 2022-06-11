using P07.RawData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine()
                {
                    Power = power,
                    Speed = speed
                };

                Cargo cargo = new Cargo()
                {
                    Type = type,
                    Weight = weight
                };

                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                Tire[] tires = new Tire[4]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();
            List<string> targetCarsList = new List<string>();

            if (cmd == "fragile")
            {
                targetCarsList = cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.FirstOrDefault(tire => tire.Pressure < 1) != null).Select(car => car.Model).ToList();
            }
            else if (cmd == "flammable")
            {
                targetCarsList = cars.Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250).Select(car => car.Model).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, targetCarsList));
        }
    }
}
