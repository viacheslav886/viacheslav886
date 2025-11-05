# 🕒 DateUtils — Утилиты для работы с датами

Мини-проект на C#, демонстрирующий работу с `DateTime`, форматирование и “человеческие” разницы между датами.

---

## 🚀 Возможности

- Проверка, является ли год високосным
- Подсчёт количества дней между датами
- Форматирование даты в виде `dd.MM.yyyy HH:mm`
- Получение "человеческой" разницы:  
  `3 дня назад`, `через 2 недели`, `только что`

---

## 💡 Пример использования

```csharp
using System;
using DateUtils;

class Program
{
    static void Main()
    {
        Console.WriteLine(DateHelper.IsLeapYear(2024)); // True
        Console.WriteLine(DateHelper.DaysBetween(DateTime.Now, DateTime.Now.AddDays(10))); // 10
        Console.WriteLine(DateHelper.FormatDate(DateTime.Now)); // "28.10.2025 16:45"
        Console.WriteLine(DateHelper.HumanizeDifference(DateTime.Now, DateTime.Now.AddHours(5))); // "через 5 часов"
    }
}
