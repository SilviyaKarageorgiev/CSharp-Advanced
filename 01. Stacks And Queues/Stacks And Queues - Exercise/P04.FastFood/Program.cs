using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int availableFood = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(input);

            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);
            int counter = 0;

            while (queue.Count > 0)
            {
                counter++;
                int currOrder = queue.Peek();

                if (availableFood - currOrder < 0)
                {
                    break;
                }             
                    queue.Dequeue();
                    availableFood -= currOrder;
                
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");

            }
            else
            {
                Console.WriteLine("Orders complete");

            }

        }
    }
}
