using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;

public class Browser
{
    private IWebDriver driver = null;

    public IWebDriver GetBrowser(string browserName = "Chrome", bool isHeadless = false)
    {
        if (driver == null)
        {
            InitBrowser(browserName, isHeadless);
        }

        return driver;
    }

    public static Browser Init()
    {
        return new Browser();
    }

    private IWebDriver InitBrowser(string browserName, bool isHeadless)
    {
        switch (browserName)
        {
            case "Firefox":
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (isHeadless)
                {
                    firefoxOptions.AddArguments("--headless");
                }

                driver = new FirefoxDriver(firefoxOptions);           
                break;

            case "Chrome":
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-extensions"); // to disable extension
                options.AddArguments("--disable-notifications"); // to disable notification
                options.AddArguments("--disable-application-cache"); // to disable cache
                options.AddArguments("--disable-web-security");
                options.AddArguments("--allow-running-insecure-content");

                if (isHeadless)
                {
                    options.AddArguments("--headless");
                }

                driver = new ChromeDriver(options);
                break;
            case "Safari":
                if (isHeadless)
                {
                    throw new Exception("Cannot run Safari on Headless mode!");
                }
                driver = new SafariDriver();
                break;

            default:
                throw new Exception("Invalid browser name!");
        }
        driver.Manage().Window.Maximize();

        return driver;
    }
}
