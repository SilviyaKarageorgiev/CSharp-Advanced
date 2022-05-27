
namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (writer)
            {
                using (reader)
                {
                    int index = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(line);

                        }
                       
                        index++;
                    }

                }
            }
            
        }
    }
}
