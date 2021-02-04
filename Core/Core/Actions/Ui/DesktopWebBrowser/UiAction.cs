using OpenQA.Selenium;

public static class UiAction
{

    /// <summary>
    ///    It will execute javascript script that effect to elements
    /// </summary>
    public static object JsExecute(this IWebDriver driver, string script, params object[] elements)
    {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        return executor.ExecuteScript(script, elements);
    }

    /// <summary>
    ///    It will move to the element and clicks (without releasing) in the middle of the given element.
    /// </summary>
    public static IWebDriver PrintScreen(this IWebDriver driver, string filePath)
    {
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        screenshot.SaveAsFile(filePath);
        return driver;
    }
}
