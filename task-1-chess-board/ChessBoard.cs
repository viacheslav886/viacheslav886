using System;

namespace ChessBoardGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Chess Board Generator");
            Console.WriteLine("=====================\n");
            
            WriteBoard(3);
            WriteBoard(5);
            WriteBoard(8);
        }

        private static void WriteBoard(int size)
        {
            Console.WriteLine($"Board size: {size}x{size}");
            
            for (var i = 1; i <= size; i++)
            {
                for (var j = 1; j <= size; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.Write("#");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
