using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            int left = 5;
            int right = 7;

            EqualityScale<int> equalityScale = new EqualityScale<int>(left, right);
            Console.WriteLine(equalityScale.AreEqual());

        }
    }
}
