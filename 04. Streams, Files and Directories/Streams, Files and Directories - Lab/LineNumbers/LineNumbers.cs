namespace LineNumbers
{
    using System;
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                using (reader)
                {
                    int line = 1;
                    string input;
                    while ((input = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{line}. {input}");
                        line++;
                    }
                }
            }
        }
    }
}
