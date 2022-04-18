using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<int, int> infoData = new Dictionary<int, int>();
            HashSet<int> set = new HashSet<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                
                if (!infoData.ContainsKey(currNum))
                {
                    infoData.Add(currNum, 0);
                }
                infoData[currNum]++;
            }

            foreach (var item in infoData)
            {
                if (item.Value % 2 == 0)
                {
                    set.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(" ", set));

        }
    }
}
