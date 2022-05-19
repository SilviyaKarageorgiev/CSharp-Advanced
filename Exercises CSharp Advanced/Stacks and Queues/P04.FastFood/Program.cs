using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currOrder = queue.Peek();

                if (currOrder > quantityOfTheFood)
                {
                    break;
                }

                quantityOfTheFood -= currOrder;
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
