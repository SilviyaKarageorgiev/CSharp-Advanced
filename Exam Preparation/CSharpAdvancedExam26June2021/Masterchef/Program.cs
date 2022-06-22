using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DIPPINGSAUCE = 150;
            const int GREENSALAD = 250;
            const int CHOCOLATECAKE = 300;
            const int LOBSTER = 400;

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            int[] inputIngredients = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputFreshness = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(inputIngredients);
            Stack<int> freshness = new Stack<int>(inputFreshness);
            Dictionary<string, int> data = new Dictionary<string, int>();

            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int result = ingredients.Peek() * freshness.Peek();

                if (result == DIPPINGSAUCE)
                {
                    dippingSauce++;
                    if (!data.ContainsKey("Dipping sauce"))
                    {
                        data["Dipping sauce"] = 0;
                    }
                    data["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == GREENSALAD)
                {
                    greenSalad++;
                    if (!data.ContainsKey("Green salad"))
                    {
                        data["Green salad"] = 0;
                    }
                    data["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == CHOCOLATECAKE)
                {
                    chocolateCake++;
                    if (!data.ContainsKey("Chocolate cake"))
                    {
                        data["Chocolate cake"] = 0;
                    }
                    data["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == LOBSTER)
                {
                    lobster++;
                    if (!data.ContainsKey("Lobster"))
                    {
                        data["Lobster"] = 0;
                    }
                    data["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count() > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var item in data.OrderBy(x => x.Key))
            {
                Console.WriteLine($"# {item.Key} --> {item.Value}");
            }
        }
    }
}
