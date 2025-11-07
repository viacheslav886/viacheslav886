
**Program.cs**
```csharp
using System;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new MatrixCalculator();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== КАЛЬКУЛЯТОР МАТРИЦ ===");
                Console.WriteLine("1. Сложение матриц");
                Console.WriteLine("2. Вычитание матриц");
                Console.WriteLine("3. Умножение матриц");
                Console.WriteLine("4. Умножение на число");
                Console.WriteLine("5. Транспонирование");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите операцию: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            calculator.AddMatrices();
                            break;
                        case "2":
                            calculator.SubtractMatrices();
                            break;
                        case "3":
                            calculator.MultiplyMatrices();
                            break;
                        case "4":
                            calculator.MultiplyByScalar();
                            break;
                        case "5":
                            calculator.TransposeMatrix();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }

    public class MatrixCalculator
    {
        public void AddMatrices()
        {
            Console.WriteLine("\n=== СЛОЖЕНИЕ МАТРИЦ ===");
            
            var matrix1 = ReadMatrix("Введите первую матрицу:");
            var matrix2 = ReadMatrix("Введите вторую матрицу:");

            if (matrix1.GetLength(0) != matrix2.GetLength(0) || 
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new InvalidOperationException("Матрицы должны быть одного размера!");
            }

            var result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            PrintResult(result);
        }

        public void SubtractMatrices()
        {
            Console.WriteLine("\n=== ВЫЧИТАНИЕ МАТРИЦ ===");
            
            var matrix1 = ReadMatrix("Введите первую матрицу:");
            var matrix2 = ReadMatrix("Введите вторую матрицу:");

            if (matrix1.GetLength(0) != matrix2.GetLength(0) || 
                matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new InvalidOperationException("Матрицы должны быть одного размера!");
            }

            var result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            PrintResult(result);
        }

        public void MultiplyMatrices()
        {
            Console.WriteLine("\n=== УМНОЖЕНИЕ МАТРИЦ ===");
            
            var matrix1 = ReadMatrix("Введите первую матрицу:");
            var matrix2 = ReadMatrix("Введите вторую матрицу:");

            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new InvalidOperationException(
                    "Количество столбцов первой матрицы должно равняться количеству строк второй матрицы!");
            }

            var result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            PrintResult(result);
        }

        public void MultiplyByScalar()
        {
            Console.WriteLine("\n=== УМНОЖЕНИЕ НА ЧИСЛО ===");
            
            var matrix = ReadMatrix("Введите матрицу:");
            Console.Write("Введите число: ");
            var scalar = double.Parse(Console.ReadLine());

            var result = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            PrintResult(result);
        }

        public void TransposeMatrix()
        {
            Console.WriteLine("\n=== ТРАНСПОНИРОВАНИЕ ===");
            
            var matrix = ReadMatrix("Введите матрицу:");
            var result = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            PrintResult(result);
        }

        private double[,] ReadMatrix(string message)
        {
            Console.WriteLine(message);
            
            Console.Write("Количество строк: ");
            int rows = int.Parse(Console.ReadLine());
            
            Console.Write("Количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            var matrix = new double[rows, cols];

            Console.WriteLine("Введите элементы матрицы построчно (через пробел):");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                var values = Console.ReadLine().Split(' ');
                
                if (values.Length != cols)
                {
                    throw new ArgumentException("Неверное количество элементов в строке!");
                }

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }

            return matrix;
        }

        private void PrintResult(double[,] matrix)
        {
            Console.WriteLine("\nРезультат:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],8:F2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
