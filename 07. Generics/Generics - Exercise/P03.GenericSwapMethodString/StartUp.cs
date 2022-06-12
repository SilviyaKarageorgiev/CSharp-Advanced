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

            string indeces = Console.ReadLine();
            int index1 = int.Parse(indeces.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            int index2 = int.Parse(indeces.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

            string toSwapIndex1 = box.Items[index1];
            string toSwapIndex2 = box.Items[index2];
            box.Items[index1] = toSwapIndex2;
            box.Items[index2] = toSwapIndex1;

            Console.WriteLine(box);
        }
    }
}
