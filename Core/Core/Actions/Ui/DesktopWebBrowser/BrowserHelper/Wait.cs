using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

public static class Wait
{
    public static IWebElement WaitUtil(this IWebDriver driver, By elementLocator, WaitType waitType = WaitType.WaitUtilVisible, int timeout = Constant.TimeOut)
    {
        switch (waitType)
        {
            case WaitType.WaitUtilVisible:
                return WaitUntilElementVisible(driver, elementLocator, timeout);
            case WaitType.WaitUtilExist:
                return WaitUntilElementExist(driver, elementLocator, timeout);
            case WaitType.WaitUtilClickable:
                return WaitUntilElementClickable(driver, elementLocator, timeout);
            default:
                throw new Exception("Invalid web type!");
        }
    }

    private static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not visible.");
        }
    }

    private static IWebElement WaitUntilElementExist(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not exist.");
        }
    }


    private static IWebElement WaitUntilElementClickable(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not clickable.");
        }
    }

    public static IWebDriver Sleep(this IWebDriver driver, int millisecondsTimeout)
    {
        Thread.Sleep(millisecondsTimeout);
        return driver;
    }

    //public static IWebDriver WaitAngular(this IWebDriver driver, int seconds)
    //{
    //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

    //    string hasAngularFinishedScript =
    //        @"var callback = arguments[arguments.length - 1];
    //            if (document.readyState == 'complete') {
    //                var el = document.querySelector('html');
    //                if (!window.angular) {
    //                    callback('False')
    //                }
    //                if (angular.getTestability) {
    //                    angular.getTestability(el).whenStable(function() { callback('True'); });
    //                } else {
    //                    if (!angular.element(el).injector()) {
    //                        callback('False')
    //                    }
    //                    var browser = angular.element(el).injector().get('$browser');
    //                    browser.notifyWhenNoOutstandingRequests(function() { callback('True'); });
    //                }
    //            } else {
    //                callback('False');
    //            }";

    //    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
    //    wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteAsyncScript(hasAngularFinishedScript).Equals("True"));
    //    return driver;
    //}

    //public static IWebDriver WaitDocument(this IWebDriver driver, int seconds)
    //{
    //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
    //    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
    //    wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    //    return driver;
    //}



    //public static IWebDriver WaitForPageLoad(this IWebDriver driver, int timeoutSec = 15)
    //{
    //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
    //    WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
    //    wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");

    //    return driver;
    //}

}