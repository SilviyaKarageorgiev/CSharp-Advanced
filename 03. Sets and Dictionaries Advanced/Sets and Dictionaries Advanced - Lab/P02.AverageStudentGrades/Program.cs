using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<decimal>> infoGrades = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = input[0];
                string grade = input[1];

                if (!infoGrades.ContainsKey(name))
                {
                    infoGrades[name] = new List<decimal>();
                }
                infoGrades[name].Add(decimal.Parse(grade));
            }

            foreach (var student in infoGrades)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var studentGrade in student.Value)
                {
                    Console.Write($"{studentGrade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
