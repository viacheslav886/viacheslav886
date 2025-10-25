using System;

namespace TaskTracker
{
    internal class Program
    {
        static void Main()
        {
            var manager = new TaskManager();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Task Tracker ===");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Показать все задачи");
                Console.WriteLine("0. Выход");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите описание задачи: ");
                        string desc = Console.ReadLine() ?? "";
                        manager.AddTask(desc);
                        Console.WriteLine("Задача добавлена!");
                        break;

                    case "2":
                        Console.Write("Введите ID задачи для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (manager.RemoveTask(id))
                                Console.WriteLine("Задача удалена!");
                            else
                                Console.WriteLine("Задача не найдена.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nВаши задачи:");
                        foreach (var t in manager.GetAllTasks())
                            Console.WriteLine(t);
                        break;

                    case "0":
                        running = false;
                        continue;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}
