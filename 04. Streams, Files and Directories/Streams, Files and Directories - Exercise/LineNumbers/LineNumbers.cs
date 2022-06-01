namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                using (reader)
                {
                    int counter = 1;
                    int countLetters = 0;
                    int countSymbols = 0;

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        countLetters = line.Count(char.IsLetter);
                        countSymbols = line.Count(char.IsPunctuation);
                        writer.WriteLine($"Line {counter}: {line} ({countLetters})({countSymbols})");
                        counter++;
                    }
                }
            }
        }
    }
}
