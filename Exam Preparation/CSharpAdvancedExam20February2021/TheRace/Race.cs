using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {

        private List<Racer> data;

        public List<Racer> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => Data.Count;

        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Racer racer)
        {
            if (Capacity > 0)
            {
                Data.Add(racer);
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

        public Racer GetOldestRacer()
        {
            return Data.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return Data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return Data.OrderByDescending(x => x.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
