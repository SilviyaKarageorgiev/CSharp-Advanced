using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Person> list = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (age > 30)
                {
                    Person person = new Person(name, age);
                    list.Add(person);
                }
                
            }
            
            list = list.OrderBy(p => p.Name).ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
