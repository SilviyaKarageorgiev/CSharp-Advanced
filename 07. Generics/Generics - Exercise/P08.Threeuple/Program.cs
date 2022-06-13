using System;

namespace P08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = input1[0] + " " + input1[1];
            string address = input1[2];
            string town = input1.Length > 4 ? input1[3] + " " + input1[4] : input1[3];

            Threeuple<string, string, string> personInfo = new Threeuple<string, string, string>(name, address, town);

            Console.WriteLine(personInfo);

            string[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string nameDrinker = input2[0];
            int liters = int.Parse(input2[1]);
            bool isDrunk = input2[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> drinkerInfo = new Threeuple<string, int, bool>(nameDrinker, liters, isDrunk);

            Console.WriteLine(drinkerInfo);

            string[] input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string nameBankAccount = input3[0];
            double accountBalance = double.Parse(input3[1]);
            string bankName = input3[2];

            Threeuple<string, double, string> numbersInfo = new Threeuple<string, double, string>(nameBankAccount, accountBalance, bankName);

            Console.WriteLine(numbersInfo);

        }
    }
}
