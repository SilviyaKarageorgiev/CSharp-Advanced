using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int capacityOfRack = int.Parse(Console.ReadLine());
            int currRack = capacityOfRack;
            int racks = 1;

            while (stack.Any())
            {
                if (stack.Peek() <= currRack)
                {
                    currRack -= stack.Pop();                    
                }
                else
                {
                    racks++;
                    currRack = capacityOfRack;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
