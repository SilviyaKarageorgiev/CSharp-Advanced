using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    internal class Bakery
    {

        private List<Employee> data;

        public List<Employee> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => Data.Count;

        public Bakery(string name, int capacity)
        {
            Data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Employee employee)
        {
            if (Capacity > 0)
            {
                Data.Add(employee);
                Capacity--;
            }
        }

        public bool Remove(string name)
        {
            if (Data.Any(x => x.Name == name))
            {
                Data.Remove(Data.Where(x => x.Name == name).First());
                Capacity++;
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return Data.OrderByDescending(x => x.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return Data.First(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var empl in Data)
            {
                sb.AppendLine(empl.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
