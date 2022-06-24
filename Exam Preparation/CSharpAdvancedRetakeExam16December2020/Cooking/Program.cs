using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BREAD = 25;
            const int CAKE = 50;
            const int PASTRY = 75;
            const int FRUITPIE = 100;

            Dictionary<string, int> data = new Dictionary<string, int>();
            data["Bread"] = 0;
            data["Cake"] = 0;
            data["Fruit Pie"] = 0;
            data["Pastry"] = 0;

            int[] inputLiquids = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputIngredients = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(inputLiquids);
            Stack<int> ingredients = new Stack<int>(inputIngredients);

            while (liquids.Any() && ingredients.Any())
            {
                int result = liquids.Peek() + ingredients.Peek();

                if (result == BREAD)
                {                    
                    data["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == CAKE)
                {
                    data["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == FRUITPIE)
                {
                    data["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == PASTRY)
                {
                    data["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (data["Bread"] > 0 && data["Cake"] > 0 && data["Fruit Pie"] > 0 && data["Pastry"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count() > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count() > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var item in data.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
