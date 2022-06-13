using System;

namespace P07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input1[0] + " " + input1[1];            
            string town = input1[2];

            MyTuple<string, string> personInfo = new MyTuple<string, string>(name, town);

            Console.WriteLine(personInfo);

            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string nameDrinker = input2[0];
            int liters = int.Parse(input2[1]);

            MyTuple<string, int> drinkerInfo = new MyTuple<string, int>(nameDrinker, liters);

            Console.WriteLine(drinkerInfo);

            string[] input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(input3[0]);
            double num2 = double.Parse(input3[1]);

            MyTuple<int, double> numbersInfo = new MyTuple<int, double>(num1, num2);

            Console.WriteLine(numbersInfo);
        }
    }
}
