using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(input);

            int capacity = int.Parse(Console.ReadLine());
            int rack = 1;
            int currCapacity = capacity;

            while (stack.Count > 0)
            {
                int currClothes = stack.Peek();
                
                if (currCapacity >= currClothes)
                {
                    currCapacity -= currClothes;
                    stack.Pop();
                }
                else
                {
                    rack++;
                    currCapacity = capacity;
                }
            }

            Console.WriteLine(rack);
        }
    }
}
