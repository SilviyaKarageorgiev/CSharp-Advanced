using System;
using System.Linq;

namespace P03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] sorted = numbers.OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
