using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SINK = 40;
            const int OVEN = 50;
            const int COUNTERTOP = 60;
            const int WALL = 70;

            int[] inputWhite = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputGray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> greyTiles = new Queue<int>(inputGray);
            Stack<int> whiteTiles = new Stack<int>(inputWhite);

            Dictionary<string, int> data = new Dictionary<string, int>();

            while (greyTiles.Any() && whiteTiles.Any())
            {
                if (greyTiles.Peek() == whiteTiles.Peek())
                {
                    int result = greyTiles.Peek() + whiteTiles.Peek();

                    if (result == SINK)
                    {
                        if (!data.ContainsKey("Sink"))
                        {
                            data["Sink"] = 0;
                        }
                        data["Sink"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (result == OVEN)
                    {
                        if (!data.ContainsKey("Oven"))
                        {
                            data["Oven"] = 0;
                        }
                        data["Oven"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (result == COUNTERTOP)
                    {
                        if (!data.ContainsKey("Countertop"))
                        {
                            data["Countertop"] = 0;
                        }
                        data["Countertop"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (result == WALL)
                    {
                        if (!data.ContainsKey("Wall"))
                        {
                            data["Wall"] = 0;
                        }
                        data["Wall"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else
                    {
                        if (!data.ContainsKey("Floor"))
                        {
                            data["Floor"] = 0;
                        }
                        data["Floor"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }

            }

            if (whiteTiles.Count() == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count() == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var item in data.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
