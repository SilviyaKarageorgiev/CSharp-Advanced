using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputEatingCapacity = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputPlates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> guests = new Queue<int>(inputEatingCapacity);
            Stack<int> plates = new Stack<int>(inputPlates);
            int wastedFood = 0;

            int food = 0;
            int currGuest = 0;

            while (guests.Any() && plates.Any())
            {
                food = plates.Pop();
                currGuest = guests.Dequeue();

                if ((food - currGuest) >= 0)
                {
                    wastedFood += food - currGuest;
                    currGuest = 0;
                }
                else
                {
                    currGuest -= food;

                    while (currGuest > 0)
                    {
                        food = plates.Pop();

                        if (food >= currGuest)
                        {
                            wastedFood += food - currGuest;
                        }
                        currGuest -= food;
                    }
                }
                
            }

            if (plates.Count() == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            if (guests.Count() == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            
        }
    }
}
