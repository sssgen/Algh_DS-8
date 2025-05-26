using System;

namespace levels
{
    public static class SecondLevel
    {
        enum State { Start, Digit, E, Error, Accept }

        public static void Execute()
        {
            Console.WriteLine("Введіть рядок для перевірки:");
            string input = Console.ReadLine();

            State state = State.Start;

            foreach (char c in input)
            {
                switch (state)
                {
                    case State.Start:
                        if (char.IsDigit(c)) state = State.Digit;
                        else state = State.Error;
                        break;

                    case State.Digit:
                        if (char.IsDigit(c)) state = State.Digit;
                        else if (c == 'E') state = State.E;
                        else state = State.Error;
                        break;

                    case State.E:
                        if (char.IsDigit(c)) state = State.Digit;
                        else state = State.Error;
                        break;
                }

                if (state == State.Error)
                    break;
            }

            if (state == State.Digit)
                Console.WriteLine("Рядок правильний.");
            else
                Console.WriteLine("Рядок неправильний.");
        }
    }
}
