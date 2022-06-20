using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {

        public List<Drone> Drones { get; private set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }
        public int Count
        {
            get => this.Drones.Count;
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Name == string.Empty || drone.Brand == null || drone.Brand == string.Empty)
            {
                return "Invalid drone.";
            }
            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.Capacity == 0)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            this.Capacity--;
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(x => x.Name == name))
            {
                Drone drone = Drones.First(x => x.Name == name);
                this.Drones.Remove(drone);
                this.Capacity++;
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            if (Drones.Any(x => x.Brand == brand))
            {
                int count = Drones.Where(x => x.Brand == brand).Count();
                Drones = Drones.Where(x => x.Brand != brand).ToList();
                this.Capacity -= count;
                return count;
            }
            return 0;
        }

        public Drone FlyDrone(string name)
        {
            if (Drones.Any(x => x.Name == name))
            {
                Drone drone = Drones.First(x => x.Name == name);
                drone.Available = false;
                return drone;
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {           

            foreach (Drone drone in Drones.Where(x => x.Range >= range))
            {
                drone.Available = false;
            }

            return Drones.Where(x => x.Range >= range).ToList();
        }

        public string Report()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (Drone drone in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
