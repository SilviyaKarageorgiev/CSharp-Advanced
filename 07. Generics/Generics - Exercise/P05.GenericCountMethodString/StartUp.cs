using System;

namespace P05.GenericCountMethodString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            
            Box<string> box = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                box.Items.Add(element);
            }
            string elementToCompare = Console.ReadLine();

            Console.WriteLine(box.CountGraterThan(elementToCompare));

        }
    }
}
