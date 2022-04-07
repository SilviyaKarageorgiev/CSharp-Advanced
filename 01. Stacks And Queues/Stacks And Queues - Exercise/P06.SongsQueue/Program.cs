using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string input = Console.ReadLine();
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = cmdArgs[0];
                
                if (command == "Play")
                {
                    queue.Dequeue();
                }

                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

                else if (command == "Add")
                {
                    string song = input;
                    song = song.Substring(4, input.Length - 1 - 4 + 1);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }

        }
    }
}
