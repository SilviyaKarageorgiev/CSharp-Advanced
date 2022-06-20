namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;
        }

        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }


    }
}
