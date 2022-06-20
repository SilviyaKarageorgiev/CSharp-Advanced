using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; private set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => this.Fish.Count;
        }

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.Capacity == 0)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            this.Capacity--;
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(f => f.Weight == weight))
            {
                Fish fish = Fish.First(fish => fish.Weight == weight);
                return Fish.Remove(fish);
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(f => f.FishType == fishType);
         
        }

        public Fish GetBiggestFish()
        {           
            return Fish.OrderByDescending(fish => fish.Weight).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");
            
            foreach (Fish fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
