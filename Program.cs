using System;
using levels;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Виберіть рівень виконання (1, 2 або 3):");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                FirstLevel.Execute();
                break;
            case "2":
                SecondLevel.Execute();
                break;
            case "3":
                ThirdLevel.Execute();
                break;
            default:
                Console.WriteLine("Невірний вибір. Завершення роботи.");
                break;
        }
    }
}
