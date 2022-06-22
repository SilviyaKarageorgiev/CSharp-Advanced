using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        private List<Car> participants;
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;           
        }

        public void Add(Car car)
        {
            if (!this.Participants.Any(x => x.LicensePlate == car.LicensePlate) && this.Capacity > 0 && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
                this.Capacity--;
            }
        }

        public bool Remove(string licensePlate)
        {
            if (this.Participants.Any(x => x.LicensePlate == licensePlate))
            {
                this.Participants.Remove(Participants.First(x => x.LicensePlate == licensePlate));
                this.Capacity++;
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (this.Participants.Any(x => x.LicensePlate == licensePlate))
            {
                return this.Participants.First(x => x.LicensePlate == licensePlate);
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count() > 0)
            {
                return this.Participants.OrderByDescending(x => x.HorsePower).First();
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var item in Participants)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
