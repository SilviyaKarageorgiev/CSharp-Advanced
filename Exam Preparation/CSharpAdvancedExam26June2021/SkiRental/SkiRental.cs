using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkiRental
{
    internal class SkiRental
    {
        private List<Ski> data;
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public int Count => Data.Count;

        public void Add(Ski ski)
        {
            if (this.Capacity > 0)
            {
                this.Data.Add(ski);
                this.Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null)
            {
                return false;
            }
            Data.Remove(ski);
            this.Capacity++;
            return true;
        }

        public Ski GetNewestSki()
        {
            if (Data.Count() > 0)
            {
                Ski ski = this.Data.OrderByDescending(x => x.Year).First();
                return ski;
            }
            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (ski == null)
            {
                return null;
            }
            return ski;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
