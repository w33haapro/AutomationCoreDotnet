using FluentAssertions;
using Newtonsoft.Json.Linq;

public static class SmartAssert
{
    public static void AreEqual(this object actual, object expected)
    {
        actual.Should().BeEquivalentTo(expected);
    }

    public static void AreGreaterThan(this int input, int target)
    {
        input.Should().BeGreaterThan(target);
    }

    public static void AreLessThan(this int input, int target)
    {
        input.Should().BeLessThan(target);
    }

    public static void AreEqual(this string actual, string expected)
    {
        actual.Should().BeEquivalentTo(expected);
    }

    public static void AreContain(this string input, string target)
    {
        input.Should().Contain(target);
    }

    public static void IsNotNull(this object item)
    {
        item.Should().NotBeNull();
    }

    public static void IsNull(this object item)
    {
        item.Should().BeNull();
    }

    public static void AreEqualJson(this string actual, string expected)
    {
        JToken expectedToken = JToken.Parse(expected);
        JToken actualToken = JToken.Parse(actual);
        AreEqual(expectedToken, actualToken);
    }
}