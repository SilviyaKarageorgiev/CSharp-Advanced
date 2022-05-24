using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> data = new Dictionary<int, int>();
            int number = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!data.ContainsKey(num))
                {
                    data[num] = 0;
                }
                data[num]++;
            }

            foreach (var item in data)
            {
                if (item.Value % 2 == 0)
                {
                    number = item.Key;
                    Console.WriteLine(number);
                    break;
                }
            }

        }
    }
}
