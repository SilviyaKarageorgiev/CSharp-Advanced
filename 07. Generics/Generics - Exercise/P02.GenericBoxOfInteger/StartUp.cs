using System;

namespace P01.GenericBoxOfString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                box.Items.Add(value);
            }

            Console.WriteLine(box);
        }
    }
}
