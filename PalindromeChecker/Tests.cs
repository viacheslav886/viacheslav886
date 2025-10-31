using NUnit.Framework;

[TestFixture]
public class PalindromeCheckerTests
{
    [Test]
    public void SimplePalindromes()
    {
        Assert.IsTrue(PalindromeChecker.IsPalindrome("level"));
        Assert.IsTrue(PalindromeChecker.IsPalindrome("Madam"));
    }

    [Test]
    public void PhrasePalindromes()
    {
        Assert.IsTrue(PalindromeChecker.IsPalindrome("A man a plan a canal Panama"));
        Assert.IsTrue(PalindromeChecker.IsPalindrome("А роза упала на лапу Азора"));
    }

    [Test]
    public void NotPalindromes()
    {
        Assert.IsFalse(PalindromeChecker.IsPalindrome("Hello"));
        Assert.IsFalse(PalindromeChecker.IsPalindrome("Palindrome"));
    }

    [Test]
    public void EmptyOrNullInput()
    {
        Assert.IsFalse(PalindromeChecker.IsPalindrome(""));
        Assert.IsFalse(PalindromeChecker.IsPalindrome(null));
    }
}
