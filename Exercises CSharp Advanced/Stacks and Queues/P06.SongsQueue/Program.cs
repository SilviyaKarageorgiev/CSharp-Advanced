using System;
using System.Collections.Generic;

namespace P06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (true)
            {
                string input = Console.ReadLine();
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Add")
                {
                    string song = input;
                    song = song.Substring(4, song.Length - 4);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

            }

        }
    }
}
