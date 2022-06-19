using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int SALAD = 350;
            const int SOUP = 490;
            const int PASTA = 680;
            const int STEAK = 790;

            string[] inputMeals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] inputCal = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<string> meals = new Queue<string>(inputMeals);
            Stack<int> calories = new Stack<int>(inputCal);
            int currCal = 0;
            int counterMeals = 0;
            int savedCal = 0;

            while (meals.Any() && calories.Any())
            {
                if (meals.Peek() == "salad")
                {
                    currCal = calories.Peek() - SALAD;
                }
                else if (meals.Peek() == "soup")
                {
                    currCal = calories.Peek() - SOUP;
                }
                else if (meals.Peek() == "pasta")
                {
                    currCal = calories.Peek() - PASTA;
                }
                else if (meals.Peek() == "steak")
                {
                    currCal = calories.Peek() - STEAK;
                }

                if (currCal > 0)
                {
                    meals.Dequeue();
                    counterMeals++;
                    calories.Pop();
                    calories.Push(Math.Abs(currCal));
                    currCal = 0;
                }
                else if (currCal < 0 && calories.Count() > 0)
                {
                    savedCal = calories.Pop();
                    if (calories.Any() && calories.Peek() >= Math.Abs(currCal))
                    {
                        meals.Dequeue();
                        counterMeals++;
                        calories.Push(calories.Pop() - Math.Abs(currCal));
                        currCal = 0;
                    }
                    else
                    {
                        meals.Dequeue();
                        counterMeals++;
                        calories.Push(savedCal);
                        break;
                    }
                }
               
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {counterMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {counterMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
