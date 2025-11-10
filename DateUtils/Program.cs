using System;

namespace DateUtils
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("🕒 Демонстрация возможностей DateUtils\n");

            var now = DateTime.Now;
            var future = now.AddDays(10).AddHours(3);
            var past = now.AddDays(-5);

            Console.WriteLine($"Текущая дата: {DateHelper.FormatDate(now)}");
            Console.WriteLine($"Будущая дата: {DateHelper.FormatDate(future)}");
            Console.WriteLine($"Прошлая дата: {DateHelper.FormatDate(past)}");

            Console.WriteLine($"\nРазница между {DateHelper.FormatDate(now)} и {DateHelper.FormatDate(future)}:");
            Console.WriteLine($"→ {DateHelper.DaysBetween(now, future)} дней");

            Console.WriteLine($"\n'Человеческая' разница:");
            Console.WriteLine($"→ {DateHelper.HumanizeDifference(now, future)}");
            Console.WriteLine($"→ {DateHelper.HumanizeDifference(now, past)}");

            Console.WriteLine($"\nПроверка високосных годов:");
            for (int year = 2023; year <= 2028; year++)
            {
                string leapText = DateHelper.IsLeapYear(year) ? "високосный" : "обычный";
                Console.WriteLine($"→ {year} — {leapText}");
            }

            Console.WriteLine("\n✅ Демонстрация завершена!");
        }
    }
}
