using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputHats = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputScarfs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(inputHats);
            Queue<int> scarfs = new Queue<int>(inputScarfs);

            Queue<int> sets = new Queue<int>();

            while (hats.Any() && scarfs.Any())
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Enqueue(hats.Peek() + scarfs.Peek());
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
