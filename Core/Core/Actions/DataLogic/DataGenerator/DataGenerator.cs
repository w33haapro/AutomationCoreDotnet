using System;
using System.Linq;

public static class DataGenerator
{
    private static readonly Random random = new Random();

    public static string GenerateString(int length = 10, bool isNumber = false)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        if (isNumber)
        {
            chars = "0123456789";
        }
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}