using System;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            var diff = new DateModifier();
            
            Console.WriteLine(diff.CalculateDaysBetweenTwoDates(first, second));
        }
    }
}
