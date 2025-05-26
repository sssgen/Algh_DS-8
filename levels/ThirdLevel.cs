using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace levels
{
    public static class ThirdLevel
    {
        enum State { Start, Digit, E, Error, Accept }

        private static readonly Dictionary<(State, string), State> transitions = new()
        {
            { (State.Start, "digit"), State.Digit },
            { (State.Digit, "digit"), State.Digit },
            { (State.Digit, "E"), State.E },
            { (State.E, "digit"), State.Digit }
        };

        public static void Execute()
        {
            string filePath = "split_words.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено: " + filePath);
                return;
            }

            string content = File.ReadAllText(filePath);
            string[] words = Regex.Split(content, "%|\\+|_");

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                if (IsValidWord(word))
                    Console.WriteLine($"[OK] {word}");
                else
                    Console.WriteLine($"[FAIL] {word}");
            }
        }

        private static bool IsValidWord(string word)
        {
            State state = State.Start;

            for (int i = 0; i < word.Length; i++)
            {
                string inputType = char.IsDigit(word[i]) ? "digit" : word[i].ToString();

                if (transitions.TryGetValue((state, inputType), out State nextState))
                {
                    state = nextState;
                }
                else
                {
                    return false;
                }
            }

            return state == State.Digit;
        }
    }
}
