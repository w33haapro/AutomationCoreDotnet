using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.UnitTest.Test.Actions.UI
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class ElementActionsTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = Browser.Init().GetBrowser("Chrome", true);
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ClickAndHold_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist);
            driver.ClickAndHold(element);
        }

        [Test]
        public void RightClick_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist);
            driver.RightClick(element);
        }

        [Test]
        public void DoubleClick_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist);
            driver.DoubleClick(element);
        }

        [Test]
        public void MoveToElement_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist);
            driver.MoveToElement(element);
        }

        [Test]
        public void MoveByOffset_OnValidElement_NoEception()
        {
            driver.MoveByOffset(100, 100);
        }

        [Test]
        public void DragAndDrop_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var sourceEle = driver.WaitUtil(By.Id("draggable"));
            var targetEle = driver.WaitUtil(By.Id("droppable"));
            driver.DragAndDrop(sourceEle, targetEle);
        }

        [Test]
        public void DragAndDropBy_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var sourceEle = driver.WaitUtil(By.Id("draggable"));
            var targetEle = driver.WaitUtil(By.Id("droppable"));

            int targetEleXOffset = targetEle.Location.X;
            int targetEleYOffset = targetEle.Location.Y;
            driver.DragAndDropBy(sourceEle, targetEleXOffset, targetEleYOffset);
        }

        [Test]
        public void Release_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var sourceEle = driver.WaitUtil(By.Id("draggable"));
            var targetEle = driver.WaitUtil(By.Id("droppable"));
            driver.Release(sourceEle, targetEle);
        }
    }
}
