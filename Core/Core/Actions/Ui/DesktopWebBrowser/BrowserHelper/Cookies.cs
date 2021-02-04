using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

public static class Cookies
{
    public static void AddCookie(this IWebDriver driver, string key, string value)
    {
        driver.AddCookie(new Cookie(key, value));
    }

    public static void AddCookie(this IWebDriver driver, Cookie cookie)
    {
        driver.Manage().Cookies.AddCookie(cookie);
    }

    public static void AddCookies(this IWebDriver driver, List<Cookie> cookies)
    {
        foreach (var cookie in cookies)
        {
            driver.AddCookie(cookie);
        }
    }

    public static List<Cookie> GetAllCookies(this IWebDriver driver)
    {
        List<Cookie> cookies = driver.Manage().Cookies.AllCookies.ToList();
        return cookies;
    }

    public static void DeleteAllCookies(this IWebDriver driver)
    {
        driver.Manage().Cookies.DeleteAllCookies();
    }
}

