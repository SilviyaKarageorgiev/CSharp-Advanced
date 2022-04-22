using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counterSubmissions = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            string participantSubmissions;
            while ((participantSubmissions = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = participantSubmissions.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string user = cmdArgs[0];
                if (cmdArgs[1] == "banned")
                {
                    if (!data.ContainsKey(user))
                    {
                        continue;
                    }
                    data.Remove(user);
                    continue;
                }

                string language = cmdArgs[1];
                int points = int.Parse(cmdArgs[2]);

                if (!data.ContainsKey(user))
                {
                    data[user] = new Dictionary<string, int>();
                    data[user].Add(language, points);
                }

                if (!data[user].ContainsKey(language))
                {
                    data[user][language] = points;
                }

                if (!counterSubmissions.ContainsKey(language))
                {
                    counterSubmissions[language] = 0;
                }
                counterSubmissions[language]++;

                if (points > data[user][language])
                {
                    data[user][language] = points;
                }
            }

            data = data.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var item in data)
            {
                foreach (var (course, points) in item.Value)
                {
                    Console.WriteLine($"{item.Key} | {points}");
                }
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in counterSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }
}
