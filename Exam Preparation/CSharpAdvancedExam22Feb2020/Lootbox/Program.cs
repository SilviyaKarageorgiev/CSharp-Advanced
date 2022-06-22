using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> first = new Queue<int>(input1);
            Stack<int> second = new Stack<int>(input2);
            int claimedItems = 0;

            while (first.Any() && second.Any())
            {
                int result = first.Peek() + second.Peek();

                if (result % 2 == 0)
                {
                    claimedItems += result;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }

            if (first.Count() == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (second.Count() == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
