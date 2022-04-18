using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            int[] arrElementsToEnqueue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numberOfElementsToEnqueue = input[0];
            int numberOfElementsToDequeue = input[1];
            int elementToLookFor = input[2];

            if (arrElementsToEnqueue.Length >= numberOfElementsToEnqueue)
            {
                for (int i = 0; i < arrElementsToEnqueue.Length; i++)
                {
                    queue.Enqueue(arrElementsToEnqueue[i]);
                }

            }

            if (queue.Count >= numberOfElementsToDequeue)
            {
                for (int j = 0; j < numberOfElementsToDequeue; j++)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }



        }
    }
}
