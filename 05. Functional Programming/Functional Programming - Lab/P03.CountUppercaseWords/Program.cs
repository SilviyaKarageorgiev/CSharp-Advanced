using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var upperLetterWords = input.Where(word => char.IsUpper(word[0]));

            //Func<string, bool> upperCaseFirstLetter = word => char.IsUpper(word[0]);
            //var upperLetterWords = input.Where(upperCaseFirstLetter);

            foreach (var word in upperLetterWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
