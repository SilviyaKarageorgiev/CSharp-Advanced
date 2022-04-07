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
            Stack<int> stack = new Stack<int>();
            
            int[] arrElementsToPush = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numberOfElementsToPush = input[0];
            int numberOfElementsToPop = input[1];
            int elementToLookFor = input[2];

            if (arrElementsToPush.Length >= numberOfElementsToPush)
            {
                for (int i = 0; i < arrElementsToPush.Length; i++)
                {
                    stack.Push(arrElementsToPush[i]);
                }

            }

            if (stack.Count >= numberOfElementsToPop)
            {
                for (int j = 0; j < numberOfElementsToPop; j++)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }



        }
    }
}
