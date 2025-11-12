using System;

namespace GuessNumberGame
{
    public class Game
    {
        private readonly int _secretNumber;
        private readonly int _maxAttempts;
        private int _attempts;

        public Game(int min = 1, int max = 100, int maxAttempts = 10)
        {
            if (min >= max) throw new ArgumentException("Минимум должен быть меньше максимума.");
            if (maxAttempts <= 0) throw new ArgumentException("Количество попыток должно быть положительным.");

            _secretNumber = new Random().Next(min, max + 1);
            _maxAttempts = maxAttempts;
            _attempts = 0;
        }

        /// <summary>
        /// Проверяет введённое число и возвращает результат.
        /// </summary>
        public string Guess(int number)
        {
            _attempts++;

            if (_attempts > _maxAttempts)
                return "Попытки закончились!";

            if (number == _secretNumber)
                return $"Поздравляем! Вы угадали число {_secretNumber} за {_attempts} попыток.";

            if (number < _secretNumber)
                return "Загаданное число больше.";

            return "Загаданное число меньше.";
        }

        public bool IsGameOver => _attempts >= _maxAttempts;
        public int MaxAttempts => _maxAttempts;
    }
}
