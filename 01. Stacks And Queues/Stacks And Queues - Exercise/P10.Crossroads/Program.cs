using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace P10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<string> cars = new Queue<string>();
            Queue<char> charsOfCars = new Queue<char>();

            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());
            int countCars = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }

                int currentGreenLight = durationOfGreenLight;

                while (currentGreenLight > 0 && cars.Count > 0)
                {
                    string currCar = cars.Dequeue();

                    if (currentGreenLight - currCar.Length >= 0)
                    {
                        currentGreenLight -= currCar.Length;
                        countCars++;
                        continue;
                    }

                    if (currentGreenLight + durationOfFreeWindow - currCar.Length >= 0)
                    {
                        currentGreenLight = 0;
                        countCars++;
                        continue;
                    }

                    int hittedChar = currentGreenLight + durationOfFreeWindow;

                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currCar} was hit at {currCar[hittedChar]}.");

                    Environment.Exit(0);
                }

            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countCars} total cars passed the crossroads.");
        }
    }
}
