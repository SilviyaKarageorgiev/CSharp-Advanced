using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Queue<double> waterList = new Queue<double>(input1);
            Stack<double> flourList = new Stack<double>(input2);

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            while (waterList.Count() > 0 && flourList.Count() > 0)
            {
                double water = waterList.Peek();
                double flour = flourList.Peek();

                double sum = water + flour;
                double percentOfWater = (water * 100) / sum;

                if (percentOfWater == 50)
                {
                    if (!bakedProducts.ContainsKey("Croissant"))
                    {
                        bakedProducts["Croissant"] = 0;
                    }
                    bakedProducts["Croissant"]++;
                    waterList.Dequeue();
                    flourList.Pop();
                }
                else if (percentOfWater == 40)
                {
                    if (!bakedProducts.ContainsKey("Muffin"))
                    {
                        bakedProducts["Muffin"] = 0;
                    }
                    bakedProducts["Muffin"]++;
                    waterList.Dequeue();
                    flourList.Pop();
                }
                else if (percentOfWater == 30)
                {
                    if (!bakedProducts.ContainsKey("Baguette"))
                    {
                        bakedProducts["Baguette"] = 0;
                    }
                    bakedProducts["Baguette"]++;
                    waterList.Dequeue();
                    flourList.Pop();
                }
                else if (percentOfWater == 20)
                {
                    if (!bakedProducts.ContainsKey("Bagel"))
                    {
                        bakedProducts["Bagel"] = 0;
                    }
                    bakedProducts["Bagel"]++;
                    waterList.Dequeue();
                    flourList.Pop();
                }
                else
                {
                    if (flour > water)
                    {
                        if (!bakedProducts.ContainsKey("Croissant"))
                        {
                            bakedProducts["Croissant"] = 0;
                        }
                        bakedProducts["Croissant"]++;
                        double diff = flour - water;
                        waterList.Dequeue();
                        flourList.Pop();
                        flourList.Push(diff);
                    }
                }
            }
            var dict = bakedProducts.OrderByDescending(p => p.Value).ThenBy(p => p.Key);

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (waterList.Count() > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterList)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flourList.Count() > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourList)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
