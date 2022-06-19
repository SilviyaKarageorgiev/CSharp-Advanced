using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
	public class Parking
    {
        private List<Car> data;
        private string type;
        private int capacity;

        public string Type
        {
            get => this.type;
            private set => type = value;
        }

        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

		public IReadOnlyList<Car> Data
        {
            get => this.data;
            set => this.Data = this.data;
        }

		public int Count
        {
            get => this.data.Count;
        }

        public Parking()
        {
            this.data = new List<Car>();
        }

        public Parking(string type, int capacity) : this()
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(x => ((x.Manufacturer == manufacturer) && (x.Model == model)));
            return this.data.Remove(car);
        }

        public Car GetLatestCar()
        {
			if (this.data.Count == 0)
			{
                return null;
			}
            return this.data.OrderByDescending(x => x.Year).First();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.data.FirstOrDefault(x => ((x.Manufacturer == manufacturer) && (x.Model == model)));
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (Car car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
