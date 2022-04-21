using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace P08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsData = new Dictionary<string, string>();

            string inputPasswords;
            while ((inputPasswords = Console.ReadLine()) != "end of contests")
            {
                string[] words = inputPasswords.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = words[0];
                string pass = words[1];

                passwordsData.Add(contest, pass);
            }

            Dictionary<string, Dictionary<string, int>> pointsData = new Dictionary<string, Dictionary<string, int>>();
            string totalPoints = "totalPoints";            

            string inputContests;
            while ((inputContests = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArgs = inputContests.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArgs[0];
                string pass = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (!passwordsData.ContainsKey(contest))
                {
                    continue;
                }
                if (passwordsData[contest] != pass)
                {
                    continue;
                }

                if (!pointsData.ContainsKey(username))
                {
                    pointsData[username] = new Dictionary<string, int>();
                    
                    if (!pointsData[username].ContainsKey(contest))
                    {
                        pointsData[username][contest] = 0;
                    }
                }
                if (!pointsData[username].ContainsKey(contest))
                {
                    pointsData[username][contest] = 0;

                }
                if (pointsData[username][contest] < points)
                {
                    pointsData[username][contest] = points;                    
                }

            }


            int maxPoints = 0;
            string bestCandidate = string.Empty;
            
            foreach (var candidate in pointsData)
            {
                int currSum = candidate.Value.Sum(x => x.Value);
                if (currSum > maxPoints)
                {
                    maxPoints = currSum;
                    bestCandidate = candidate.Key;
                }
            }

            var sortedData = pointsData.OrderBy(x => x.Key);

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var item in sortedData)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var (contest, points) in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }

        }
    }
}
