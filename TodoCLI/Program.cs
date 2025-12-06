using System;

namespace TodoCLI
{
    internal class Program
    {
        static void Main()
        {
            var manager = new TodoManager();
            string command;

            Console.WriteLine("📝 CLI ToDo List");
            Console.WriteLine("Команды: list, add <task>, remove <num>, done <num>, exit");

            while (true)
            {
                Console.Write("\n> ");
                command = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(command)) continue;

                if (command == "exit") break;

                if (command == "list")
                    manager.ListTasks();
                else if (command.StartsWith("add "))
                    manager.Add(command[4..].Trim());
                else if (command.StartsWith("remove "))
                    manager.Remove(int.Parse(command[7..].Trim()) - 1);
                else if (command.StartsWith("done "))
                    manager.MarkDone(int.Parse(command[5..].Trim()) - 1);
                else
                    Console.WriteLine("Неизвестная команда.");
            }

            Console.WriteLine("Выход. До новых задач!");
        }
    }
}
