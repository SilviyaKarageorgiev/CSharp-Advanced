using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, HashSet<string>>> data = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string firstVlogger = cmdArgs[0];
                string command = cmdArgs[1];

                if (command == "joined")
                {
                    if (!data.ContainsKey(firstVlogger))
                    {
                        data[firstVlogger] = new Dictionary<string, HashSet<string>>();
                        data[firstVlogger].Add("following", new HashSet<string>());
                        data[firstVlogger].Add("followers", new HashSet<string>());
                    }
                }

                else if (command == "followed")
                {
                    string secondVlogger = cmdArgs[2];
                    if (firstVlogger == secondVlogger)
                    {
                        continue;
                    }

                    if (!data.ContainsKey(secondVlogger) || !data.ContainsKey(firstVlogger))
                    {
                        continue;
                    }

                    if (!data[firstVlogger]["following"].Contains(secondVlogger) && !data[secondVlogger]["followers"].Contains(firstVlogger))
                    {
                        data[secondVlogger]["followers"].Add(firstVlogger);
                        data[firstVlogger]["following"].Add(secondVlogger);
                    }
                }
            }

            Console.WriteLine($"The V - Logger has a total of {data.Count} vloggers in its logs.");

            var sortedVlogers = data.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int counter = 1;
            foreach (var currVlogger in sortedVlogers)
            {
                Console.WriteLine($"{counter}. {currVlogger.Key} : {currVlogger.Value["followers"].Count} followers, {currVlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var item in currVlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
        }
    }
}
