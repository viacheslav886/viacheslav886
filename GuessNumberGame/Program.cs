using System;

namespace GuessNumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("🎯 Добро пожаловать в игру 'Угадай число'!");
            Console.WriteLine("Компьютер загадал число от 1 до 100. У вас есть 10 попыток.\n");

            var game = new Game(1, 100, 10);

            while (!game.IsGameOver)
            {
                Console.Write("Введите число: ");
                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Ошибка ввода. Введите целое число.");
                    continue;
                }

                string result = game.Guess(guess);
                Console.WriteLine(result);

                if (result.StartsWith("Поздравляем"))
                    break;
            }

            Console.WriteLine("\nСпасибо за игру! 👋");
        }
    }
}
