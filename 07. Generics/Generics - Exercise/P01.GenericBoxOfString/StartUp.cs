using System;

namespace P01.GenericBoxOfString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                box.Items.Add(value);
            }

            Console.WriteLine(box);
        }
    }
}
