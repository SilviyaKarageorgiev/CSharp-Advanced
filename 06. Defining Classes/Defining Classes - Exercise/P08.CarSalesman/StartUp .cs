using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = String.Empty;

                if (input.Length == 3)
                {
                    string wordOrNot = input[2];
                    if (Char.IsDigit(wordOrNot[0]))
                    {
                        displacement = int.Parse(wordOrNot);
                    }
                    else
                    {
                        efficiency = wordOrNot;
                    }
                    
                }
                else if (input.Length == 4)
                {
                    string wordOrNot = input[2];
                    if (Char.IsDigit(wordOrNot[0]))
                    {
                        displacement = int.Parse(wordOrNot);
                    }
                    if (Char.IsLetter(wordOrNot[0]))
                    {
                        efficiency = wordOrNot;
                    }
                    string wordOrNot2 = input[3];
                    if (Char.IsDigit(wordOrNot2[0]))
                    {
                        displacement = int.Parse(wordOrNot2);
                    }
                    if (Char.IsLetter(wordOrNot2[0]))
                    {
                        efficiency = wordOrNot2;
                    }
                }
                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            

            for (int j = 0; j < m; j++)
            {
                int weight = 0;
                string color = string.Empty;
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engineModel = input[1];

                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);

                if (input.Length == 3)
                {
                    string weightOrColor = input[2];
                    if (Char.IsDigit(weightOrColor[0]))
                    {
                        weight = int.Parse(weightOrColor);
                    }
                    else
                    {
                        color = weightOrColor;
                    }
                }
                else if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine(car.Engine.Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine(car.Engine.Efficiency == string.Empty ? "    Efficiency: n/a" : $"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine(car.Weight == 0 ? "  Weight: n/a" : $"  Weight: {car.Weight}");
                Console.WriteLine(car.Color == string.Empty ? "  Color: n/a" : $"  Color: {car.Color}");
            }
        }
    }
}
