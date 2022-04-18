using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> kids = new Queue<string>(input);

            int n = int.Parse(Console.ReadLine());

            int count = 1;
            while (kids.Count > 1)
            {
                if (count == n)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    count = 1;
                }
                else
                {
                    string kid = kids.Dequeue();
                    kids.Enqueue(kid);
                    count++;
                }

            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
