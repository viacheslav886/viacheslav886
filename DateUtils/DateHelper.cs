using System;

namespace DateUtils
{
    public static class DateHelper
    {
        /// <summary>
        /// Проверяет, является ли год високосным.
        /// </summary>
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        /// Возвращает количество дней между двумя датами.
        /// </summary>
        public static int DaysBetween(DateTime from, DateTime to)
        {
            return Math.Abs((to - from).Days);
        }

        /// <summary>
        /// Форматирует дату в виде "dd.MM.yyyy HH:mm".
        /// </summary>
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd.MM.yyyy HH:mm");
        }

        /// <summary>
        /// Возвращает "человеческое" описание временного интервала между датами.
        /// Пример: "3 дня назад", "через 2 недели", "только что".
        /// </summary>
        public static string HumanizeDifference(DateTime from, DateTime to)
        {
            var diff = to - from;
            bool inFuture = diff.TotalSeconds > 0;
            var span = TimeSpan.FromSeconds(Math.Abs(diff.TotalSeconds));

            string text;
            if (span.TotalSeconds < 60)
                text = "только что";
            else if (span.TotalMinutes < 60)
                text = $"{(int)span.TotalMinutes} минут";
            else if (span.TotalHours < 24)
                text = $"{(int)span.TotalHours} часов";
            else if (span.TotalDays < 7)
                text = $"{(int)span.TotalDays} дней";
            else if (span.TotalDays < 30)
                text = $"{(int)(span.TotalDays / 7)} недель";
            else
                text = $"{(int)(span.TotalDays / 30)} месяцев";

            if (text == "только что")
                return text;

            return inFuture ? $"через {text}" : $"{text} назад";
        }
    }
}
