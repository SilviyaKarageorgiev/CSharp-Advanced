using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> set = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string direction = cmdArg[0];
                string carNumber = cmdArg[1];

                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    set.Remove(carNumber);
                }
            }

            if (set.Any())
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
