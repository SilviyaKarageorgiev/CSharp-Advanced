using System.Text;

namespace Drones
{
    public class Drone
    {

        private string name;
        private string brand;
        private int range;
        private bool available;

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            this.Available = true;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {this.Brand}");
            sb.AppendLine($"Range: {this.Range} kilometers");
            return sb.ToString().TrimEnd();
        }
    }
}
