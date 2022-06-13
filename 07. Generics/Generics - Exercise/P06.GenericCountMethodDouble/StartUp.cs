using System;

namespace P06.GenericCountMethodDouble
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            
            Box<double> box = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                box.Items.Add(element);
            }
            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountGraterThan(elementToCompare));

        }
    }
}
