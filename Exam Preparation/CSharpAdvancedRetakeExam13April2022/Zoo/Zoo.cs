using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string AddAnimal (Animal animal)
        {

            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Capacity == 0)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            this.Capacity--;
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = Animals.Where(a => a.Species == species).Count();
            Animals = Animals.Where(a => a.Species != species).ToList();
            this.Capacity -= count;
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(a => a.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int counter = Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {counter} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
