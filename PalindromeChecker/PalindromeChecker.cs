using System;
using System.Linq;

public static class PalindromeChecker
{
    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        var normalized = new string(
            input.ToLowerInvariant().Where(char.IsLetterOrDigit).ToArray()
        );

        return normalized.SequenceEqual(normalized.Reverse());
    }
}
