using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<char> pear = new List<char>{ 'p', 'e', 'a', 'r' };
            List<char> flour = new List<char> { 'f', 'l', 'o', 'u', 'r' };
            List<char> pork = new List<char>{ 'p', 'o', 'r', 'k' };
            List<char> olive = new List<char>{ 'o', 'l', 'i', 'v', 'e' };

            List<string> words = new List<string>();

            char[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            Queue<char> vowels = new Queue<char>(input1);
            Stack<char> consonants = new Stack<char>(input2);

            while (consonants.Count() > 0)
            {
                char vowel = vowels.Peek();
                char consonant = consonants.Pop();

                CheckPear(vowel, consonant, pear, words);
                CheckFlour(vowel, consonant, flour, words);
                CheckPork(vowel, consonant, pork, words);
                CheckOlive(vowel, consonant, olive, words);

                vowels.Enqueue(vowels.Dequeue());
            }

            Console.WriteLine($"Words found: {words.Count()}");

            string[] wordsInOrder =
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };

            for (int i = 0; i < wordsInOrder.Length; i++)
            {
                if (words.Contains(wordsInOrder[i]))
                {
                    Console.WriteLine(wordsInOrder[i]);
                }
            }
        }

        private static void CheckOlive(char vowel, char consonant, List<char> olive, List<string> words)
        {
            if (olive.Contains(vowel))
            {
                olive.Remove(vowel);
            }
            if (olive.Contains(consonant))
            {
                olive.Remove(consonant);
            }
            if (olive.Count() == 0 && !words.Contains("olive"))
            {
                words.Add("olive");
            }
        }

        private static void CheckPork(char vowel, char consonant, List<char> pork, List<string> words)
        {
            if (pork.Contains(vowel))
            {
                pork.Remove(vowel);
            }
            if (pork.Contains(consonant))
            {
                pork.Remove(consonant);
            }
            if (pork.Count() == 0 && !words.Contains("pork"))
            {
                words.Add("pork");
            }
        }

        private static void CheckFlour(char vowel, char consonant, List<char> flour, List<string> words)
        {
            if (flour.Contains(vowel))
            {
                flour.Remove(vowel);
            }
            if (flour.Contains(consonant))
            {
                flour.Remove(consonant);
            }
            if (flour.Count() == 0 && !words.Contains("flour"))
            {
                words.Add("flour");
            }
        }

        private static void CheckPear(char vowel, char consonant, List<char> pear, List<string> words)
        {
            if (pear.Contains(vowel))
            {
                pear.Remove(vowel);
            }
            if (pear.Contains(consonant))
            {
                pear.Remove(consonant);
            }
            if (pear.Count() == 0 && !words.Contains("pear"))
            {
                words.Add("pear");
            }
        }
    }
}
