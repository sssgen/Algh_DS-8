using System;
using System.IO;
using System.Text.RegularExpressions;

namespace levels
{
    public static class FirstLevel
    {
        private static readonly string pattern = @"(\d+E)+\d+";

        public static void Execute()
        {
            string filePath = "words.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено: " + filePath);
                return;
            }

            Console.WriteLine("Слова, що відповідають регулярному виразу:");
            foreach (var line in File.ReadLines(filePath))
            {
                if (Regex.IsMatch(line, pattern))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
