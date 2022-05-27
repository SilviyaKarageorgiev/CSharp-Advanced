namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader words = new StreamReader(wordsFilePath);
            StreamReader text = new StreamReader(textFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            Dictionary<string, int> data = new Dictionary<string, int>();
            List<string> currList = new List<string>();
            List<string> currLineText = new List<string>();


            using (words)
            {
                string wordLine;
                while ((wordLine = words.ReadLine()) != null)
                {
                    currList = wordLine.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    for (int i = 0; i < currList.Count; i++)
                    {
                        data[currList[i]] = 0;
                    }
                    using (text)
                    {
                        string line;
                        while ((line = text.ReadLine()) != null)
                        {
                            currLineText = line.ToLower().Split(new string[] { ",", " ", ".", "!", "?", "-", "...", "?!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            for (int i = 0; i < currLineText.Count; i++)
                            {
                                if (data.ContainsKey(currLineText[i]))
                                {
                                    data[currLineText[i]]++;
                                }
                            }
                        }

                    }
                }
            }

            data = data.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            using (writer)
            {
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
