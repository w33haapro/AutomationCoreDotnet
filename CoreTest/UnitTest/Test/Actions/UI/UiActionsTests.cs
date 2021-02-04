using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.UnitTest.Test.Actions.UI
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class UiActionsTests
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
        public void JsExecute_ValidScript_Success()
        {
            var element = driver.WaitUtil(By.Id("submit"));
            driver.JsExecute("arguments[0].click();", element);
        }

        [Test]
        public void PrintScreem_ValidFileName_Success()
        {
            driver.PrintScreen("image.png");
        }
    }
}
