using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int theNumberOfWavesOfOrcs = int.Parse(Console.ReadLine());
            int[] platesOfArgornDefense = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>(platesOfArgornDefense);
            Stack<int> orcs = new Stack<int>();
            int currPlate = 0;
            int currOrc = 0;

            for (int i = 1; i <= theNumberOfWavesOfOrcs; i++)
            {
                if (!plates.Any() && i % 3 != 0)
                {
                    break;
                }
                int[] wave = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                orcs = new Stack<int>(wave);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (plates.Any() && orcs.Any())
                {

                    currPlate = plates.Peek();
                    currOrc = orcs.Peek();

                    if (currOrc > currPlate)
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                        currPlate = 0;
                        currOrc = 0;
                    }
                    else if (currOrc < currPlate)
                    {
                        currPlate -= orcs.Pop();
                        plates.Dequeue();
                        plates.Enqueue(currPlate);
                        for (int j = 0; j < plates.Count() - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                        continue;
                    }
                    else if (currOrc == currPlate)
                    {
                        orcs.Pop();
                        plates.Dequeue();
                        currPlate = 0;
                        currOrc = 0;
                    }
                }

            }

            if (orcs.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}

