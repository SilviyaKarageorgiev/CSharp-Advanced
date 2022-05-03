using System;
using System.Linq;

namespace P04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            var result = input.Select(x => x += x * 0.2);

            foreach (var item in result)
            {
                Console.WriteLine($"{item:f2}");
            }

        }
    }
}
