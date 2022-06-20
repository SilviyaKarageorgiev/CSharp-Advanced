using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double GLADIUS = 70;
            const double SHAMSHIR = 80;
            const double KATANA = 90;
            const double SABRE = 110;
            const double BROADSWORD = 150;

            int gladius = 0;
            int shamshir = 0;
            int katana = 0;
            int sabre = 0;
            int broadsword = 0;

            double[] inputSteel = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] inputCarbon = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Queue<double> steel = new Queue<double>(inputSteel);
            Stack<double> carbon = new Stack<double>(inputCarbon);
            Dictionary<string, int> swords = new Dictionary<string, int>();

            while (steel.Any() && carbon.Any())
            {
                double result = steel.Peek() + carbon.Peek();

                if (result == GLADIUS)
                {
                    gladius++;
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords["Gladius"] = 0;
                    }
                    swords["Gladius"]++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (result == SHAMSHIR)
                {
                    shamshir++;
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords["Shamshir"] = 0;
                    }
                    swords["Shamshir"]++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (result == KATANA)
                {
                    katana++;
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords["Katana"] = 0;
                    }
                    swords["Katana"]++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (result == SABRE)
                {
                    sabre++;
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords["Sabre"] = 0;
                    }
                    swords["Sabre"]++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (result == BROADSWORD)
                {
                    broadsword++;
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords["Broadsword"] = 0;
                    }
                    swords["Broadsword"]++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);
                }
            }

            int forgedSwords = gladius + shamshir + katana + sabre + broadsword;
            if (forgedSwords > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count() == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count() == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var item in swords.OrderBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
