# 🔢 PalindromeChecker

Простой C# проект, который проверяет, является ли заданная строка палиндромом.

## 📄 Описание

Программа удаляет пробелы, игнорирует регистр и проверяет, читается ли строка одинаково слева направо и справа налево.

## 🚀 Пример использования

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(PalindromeChecker.IsPalindrome("А роза упала на лапу Азора")); // true
        Console.WriteLine(PalindromeChecker.IsPalindrome("Привет")); // false
    }
}
