using PasswordGenerator.Models;
using PasswordGenerator.Services;

namespace PasswordGenerator;

class Program
{
    private static readonly PasswordGeneratorService _generator = new();
    private static readonly PasswordStrengthChecker _checker = new();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        ShowWelcomeMessage();

        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GenerateSinglePassword();
                    break;
                case "2":
                    GenerateMultiplePasswords();
                    break;
                case "3":
                    CheckPasswordStrength();
                    break;
                case "4":
                    ShowOptions();
                    break;
                case "0":
                    Console.WriteLine("До свидания! 👋");
                    return;
                default:
                    Console.WriteLine("❌ Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void ShowWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================");
        Console.WriteLine("      🔐 ГЕНЕРАТОР ПАРОЛЕЙ");
        Console.WriteLine("====================================");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowMenu()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Сгенерировать один пароль");
        Console.WriteLine("2. Сгенерировать несколько паролей");
        Console.WriteLine("3. Проверить сложность пароля");
        Console.WriteLine("4. Настройки генерации");
        Console.WriteLine("0. Выход");
        Console.Write("Ваш выбор: ");
    }

    static void GenerateSinglePassword()
    {
        Console.WriteLine("\n--- Генерация пароля ---");
        
        var options = GetPasswordOptions();
        var password = _generator.GeneratePassword(options);
        var result = _checker.AnalyzePassword(password);

        DisplayPasswordResult(result);
    }

    static void GenerateMultiplePasswords()
    {
        Console.Write("\nСколько паролей сгенерировать? ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count < 1)
        {
            Console.WriteLine("❌ Неверное количество");
            return;
        }

        var options = GetPasswordOptions();
        
        Console.WriteLine($"\n--- Сгенерированные пароли ({count} шт.) ---");
        
        for (int i = 0; i < count; i++)
        {
            var password = _generator.GeneratePassword(options);
            var result = _checker.AnalyzePassword(password);
            
            Console.WriteLine($"{i + 1}. {result.Password} [{result.Strength}]");
        }
    }

    static void CheckPasswordStrength()
    {
        Console.Write("\nВведите пароль для проверки: ");
        var password = Console.ReadLine() ?? "";

        var result = _checker.AnalyzePassword(password);
        DisplayPasswordResult(result);
    }

    static void ShowOptions()
    {
        Console.WriteLine("\n--- Текущие настройки ---");
        Console.WriteLine("Эти настройки используются при генерации паролей");
        // Можно добавить сохранение/загрузку настроек
    }

    static PasswordOptions GetPasswordOptions()
    {
        var options = new PasswordOptions();

        Console.Write("Длина пароля (по умолчанию 12): ");
        if (int.TryParse(Console.ReadLine(), out int length) && length > 0)
            options.Length = length;

        Console.Write("Включать заглавные буквы? (y/n, по умолчанию y): ");
        var response = Console.ReadLine()?.ToLower();
        options.IncludeUppercase = response != "n";

        Console.Write("Включать строчные буквы? (y/n, по умолчанию y): ");
        response = Console.ReadLine()?.ToLower();
        options.IncludeLowercase = response != "n";

        Console.Write("Включать цифры? (y/n, по умолчанию y): ");
        response = Console.ReadLine()?.ToLower();
        options.IncludeNumbers = response != "n";

        Console.Write("Включать специальные символы? (y/n, по умолчанию y): ");
        response = Console.ReadLine()?.ToLower();
        options.IncludeSpecialChars = response != "n";

        Console.Write("Исключать похожие символы (1,l,I,0,O)? (y/n, по умолчанию n): ");
        response = Console.ReadLine()?.ToLower();
