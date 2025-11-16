using System;

namespace SnakeAI
{
    public class Game
    {
        private readonly int width;
        private readonly int height;
        private readonly Snake snake;
        private (int x, int y) food;

        public Game(int width = 20, int height = 15)
        {
            this.width = width;
            this.height = height;

            snake = new Snake(width / 2, height / 2);
            SpawnFood();
        }

        private void SpawnFood()
        {
            Random rnd = new();
            int x, y;

            do
            {
                x = rnd.Next(width);
                y = rnd.Next(height);
            }
            while (snake.Contains(x, y));

            food = (x, y);
        }

        private void SnakeAI()
        {
            var head = snake.Body.First!.Value;

            int dx = Math.Sign(food.x - head.x);
            int dy = Math.Sign(food.y - head.y);

            snake.Direction = Math.Abs(food.x - head.x) > Math.Abs(food.y - head.y)
                ? (dx, 0)
                : (0, dy);
        }

        public void Run()
        {
            while (true)
            {
                SnakeAI();

                var head = snake.Body.First!.Value;
                bool grow = head == food;

                snake.Move(grow);

                if (grow)
                    SpawnFood();

                var newHead = snake.Body.First!.Value;

                if (newHead.x < 0 || newHead.x >= width ||
                    newHead.y < 0 || newHead.y >= height)
                {
                    Console.Clear();
                    Console.WriteLine("💀 Змейка врезалась в стену! Игра окончена.");
                    break;
                }

                Console.Clear();
                Draw();
                System.Threading.Thread.Sleep(120);
            }
        }

        private void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (snake.Body.First!.Value == (x, y)) Console.Write("O");
                    else if (snake.Contains(x, y)) Console.Write("o");
                    else if (food == (x, y)) Console.Write("@");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
        }
    }
}
