using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input;            
            while ((input = Console.ReadLine()) != "Party!" && guests.Count > 0)
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string action = parts[1];
                string value = parts[2];

                Predicate<string> predicate = null;
                List<string> finalListOfGuests = guests.ToList();

                if (command == "Double")
                {
                    if (action == "StartsWith")
                    {
                        predicate = name => name.Substring(0, value.Length) == value;
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Add(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();
                        
                    }
                    else if (action == "EndsWith")
                    {
                        predicate = name => name.Substring(name.Length - value.Length, value.Length) == value;
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Add(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();
                    }
                    else if (action == "Length")
                    {
                        predicate = name => name.Length == int.Parse(value);
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Add(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();
                    }
                }

                else if (command == "Remove")
                {
                    if (action == "StartsWith")
                    {
                        predicate = name => name.Substring(0, value.Length) == value;
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Remove(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();

                    }
                    else if (action == "EndsWith")
                    {
                        predicate = name => name.Substring(name.Length - value.Length, value.Length) == value;
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Remove(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();
                    }
                    else if (action == "Length")
                    {
                        predicate = name => name.Length == int.Parse(value);
                        foreach (var name in guests)
                        {
                            if (predicate(name))
                            {
                                finalListOfGuests.Remove(name);
                            }
                        }
                        guests.Clear();
                        guests = finalListOfGuests.ToList();
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
