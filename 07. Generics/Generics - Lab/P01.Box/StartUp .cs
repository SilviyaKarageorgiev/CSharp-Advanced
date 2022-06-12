using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            BoxOfT<int> box = new BoxOfT<int>();
            box.Add(1);
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);

        }   
    }
}
