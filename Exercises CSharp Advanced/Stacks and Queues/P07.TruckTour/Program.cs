using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            int tank = 0;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                queue.Enqueue(input);
            }

            int startIndex = 0;
            int counter = 0;

            while (true)
            {
                foreach (var item in queue)
                {
                    int petrol = item[0];
                    int distance = item[1];
                    tank += petrol;
                    if (tank >= distance)
                    {
                        counter++;
                        tank -= distance;
                    }
                    else
                    {
                        tank = 0;
                        startIndex++;
                        queue.Enqueue(queue.Dequeue());
                        break;
                    }
                }

                if (counter == n)
                {
                    break;
                }
                else
                {
                    counter = 0;
                    continue;
                }

            }
            Console.WriteLine(startIndex);
        }
    }
}
