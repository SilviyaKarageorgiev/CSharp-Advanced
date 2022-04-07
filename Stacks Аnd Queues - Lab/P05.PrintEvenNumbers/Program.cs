using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(arr);
            Queue<int> evenNumbers = new Queue<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenNumbers.Enqueue(arr[i]);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));

        }
    }
}
