using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public static class ElementAction
{

    /// <summary>
    ///    It will move to the element and clicks (without releasing) in the middle of the given element.
    /// </summary>
    public static void ClickAndHold(this IWebDriver driver, IWebElement element)
    {
        Actions actionProvider = new Actions(driver);
        // Perform click-and-hold action on the element
        actionProvider.ClickAndHold(element).Build().Perform();
    }

    /// <summary>
    ///    This method firstly performs a mouse-move to the location of the element and performs the context-click (right click) on the given element.
    /// </summary>
    public static void RightClick(this IWebDriver driver, IWebElement element)
    {
        Actions actionProvider = new Actions(driver);
        // Perform context-click action on the element
        actionProvider.ContextClick(element).Build().Perform();
    }

    /// <summary>
    ///   It will move to the element and performs a double-click in the middle of the given element.
    /// </summary>
    public static void DoubleClick(this IWebDriver driver, IWebElement element)
    {
        Actions actionProvider = new Actions(driver);
        // Perform double-click action on the element
        actionProvider.DoubleClick(element).Build().Perform();
    }


    /// <summary>
    ///   This method moves the mouse to the middle of the element. The element is also scrolled into the view on performing this action.
    /// </summary>
    public static void MoveToElement(this IWebDriver driver, IWebElement element)
    {
        Actions actionProvider = new Actions(driver);
        actionProvider.MoveToElement(element).Build().Perform();
    }


    /// <summary>
    ///   This method moves the mouse from its current position (or 0,0) by the given offset. If the coordinates are outside the view window, then the mouse will end up outside the browser window.
    /// </summary>
    public static void MoveByOffset(this IWebDriver driver, int xOffset, int yOffset)
    {
        Actions actionProvider = new Actions(driver);
        // Performs mouse move action onto the offset position
        actionProvider.MoveByOffset(xOffset, yOffset).Build().Perform();
    }


    /// <summary>
    ///   This method firstly performs a click-and-hold on the source element, moves to the location of the target element and then releases the mouse.
    /// </summary>
    public static void DragAndDrop(this IWebDriver driver, IWebElement sourceElement, IWebElement targetElement)
    {
        Actions actionProvider = new Actions(driver);
        // Performs drag and drop action of sourceEle onto the targetEle
        actionProvider.DragAndDrop(sourceElement, targetElement).Build().Perform();
    }


    /// <summary>
    ///   This method firstly performs a click-and-hold on the source element, moves to the given offset and then releases the mouse.
    /// </summary>
    public static void DragAndDropBy(this IWebDriver driver, IWebElement sourceElement, int targetEleOffsetX, int targetEleOffsetY)
    {

        Actions actionProvider = new Actions(driver);
        // Performs drag and drop action of sourceEle onto the targetEle
        actionProvider.DragAndDropToOffset(sourceElement, targetEleOffsetX, targetEleOffsetY).Build().Perform();
    }


    /// <summary>
    ///   This action releases the depressed left mouse button. If WebElement is passed, it will release depressed left mouse button on the given WebElement
    /// </summary>
    public static void Release(this IWebDriver driver, IWebElement sourceElement, IWebElement targetElement)
    {

        Actions actionProvider = new Actions(driver);
        actionProvider.ClickAndHold(sourceElement).MoveToElement(targetElement).Build().Perform();
        // Performs release event              
        actionProvider.Release().Build().Perform();
    }
}
