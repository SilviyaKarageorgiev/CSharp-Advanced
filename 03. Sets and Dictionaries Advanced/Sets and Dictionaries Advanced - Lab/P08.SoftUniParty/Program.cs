using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();

            string reservationNumber;
            while ((reservationNumber = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(reservationNumber[0]))
                {
                    VIP.Add(reservationNumber);
                }
                else
                {
                    regular.Add(reservationNumber);
                }
            }

            string guest;
            while ((guest = Console.ReadLine()) != "END")
            {
                if (regular.Contains(guest))
                {
                    regular.Remove(guest);
                }
                if (VIP.Contains(guest))
                {
                    VIP.Remove(guest);
                }
            }

            Console.WriteLine(VIP.Count + regular.Count);

            if (VIP.Any())
            {
                foreach (var item in VIP)
                {
                    Console.WriteLine(item);
                }
            }
            
            if (regular.Any())
            {
                foreach (var item in regular)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
