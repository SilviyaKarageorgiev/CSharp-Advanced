using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => Renovators.Count;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string AddRenovator(Renovator renovator)
        {
            if (Renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Type == null || renovator.Type == string.Empty || renovator.Name == null || renovator.Type == string.Empty)
            {
                return "Invalid renovator's information.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = Renovators.Where(x => x.Name == name).First();
                Renovators.Remove(renovator);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int counter = 0;
            if (Renovators.Any(x => x.Type == type))
            {
                List<Renovator> renovators = new List<Renovator>();
                renovators = Renovators.Where(x => x.Type == type).ToList();
                foreach (Renovator renovator in renovators)
                {
                    Renovators.Remove(renovator);
                    counter++;
                }
                return counter;
            }
            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = Renovators.Where(x => x.Name == name).First();
                renovator.Hired = true;
                return renovator;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = new List<Renovator>();
            renovators = Renovators.Where(x => x.Days >= days).ToList();

            return renovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");
            List<Renovator> list = Renovators.Where(x => x.Hired == false).ToList();
            foreach (var renovator in list)
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

