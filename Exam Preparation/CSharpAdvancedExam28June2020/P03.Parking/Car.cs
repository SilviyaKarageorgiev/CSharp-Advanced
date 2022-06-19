namespace Parking
{
	public class Car
    {
        private string manufacturer;
        private string model;
        private int year;

        public string Manufacturer
        {
            get => this.manufacturer;
            private set => this.manufacturer = value;
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            private set => this.year = value;
        }

        public Car(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public override string ToString() => $"{this.Manufacturer} {this.Model} ({this.Year})";
    }
}
