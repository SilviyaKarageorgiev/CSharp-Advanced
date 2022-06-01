namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            ProcessLines(inputFilePath);
        }

        public static void ProcessLines(string inputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            int counter = 0;

            using (reader)
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        line = Replace(line);
                        line = Reverse(line);
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }

        }

        private static string Reverse(string line)
        {
            line = string.Join(" ", line.Split(' ').Reverse());
            return line;

        }

        private static string Replace(string line)
        {
            return line.Replace("-", "@").Replace(",", "@").Replace(".", "@").Replace("?", "@").Replace("!", "@");
        }

    }

}
