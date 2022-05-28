namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader reader1 = new StreamReader(firstInputFilePath);
            StreamReader reader2 = new StreamReader(secondInputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader1)
            {
                using (reader2)
                {
                    using (writer)
                    {
                        while (!reader1.EndOfStream || !reader2.EndOfStream)
                        {
                            if (reader1 != null)
                            {
                                writer.WriteLine(reader1.ReadLine());
                            }
                            if (reader2 != null)
                            {
                                writer.WriteLine(reader2.ReadLine());
                            }
                        }
                    }
                }
            }
        }
    }
}
