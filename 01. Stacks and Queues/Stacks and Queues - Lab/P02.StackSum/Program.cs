using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(input);

            string cmd;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "add")
                {
                    stack.Push(int.Parse(cmdArgs[1]));
                    stack.Push(int.Parse(cmdArgs[2]));
                }
                if (command == "remove")
                {
                    int value = int.Parse(cmdArgs[1]);
                    if (value > stack.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < value; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            //Console.WriteLine($"Sum: {stack.Sum()}");

            int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
