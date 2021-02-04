using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Core.UnitTest.Test.Actions.UI.BrowserHelperTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class WaitTests
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
        public void WaitUtil_WaitUtilElementIsExist_Successfully()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist);
            element.IsNotNull();
        }

        [Test]
        public void WaitUtil_WaitUtilElementIsVisible_Successfully()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilVisible);
            element.IsNotNull();
        }

        [Test]
        public void WaitUtil_WaitUtilElementIsClickable_Successfully()
        {
            By firstName = By.Id("firstName");
            var element = driver.WaitUtil(firstName, WaitType.WaitUtilClickable);
            element.IsNotNull();
        }


        [Test]
        public void WaitUtil_WaitUtilElementIsExistAndTimeoutIsExceed_Successfully()
        {
            By firstName = By.Id("firstNameInvalid");
            try
            {
                var element = driver.WaitUtil(firstName, WaitType.WaitUtilExist, 1);
            }
            catch (Exception e)
            {
                e.Message.AreEqual("Element with locator: '" + firstName + "' was not exist.");
            }

        }


        [Test]
        public void WaitUtil_WaitUtilElementIsVisibleAndTimeoutIsExceed_Successfully()
        {
            By firstName = By.Id("firstNameInvalid");

            try
            {
                var element = driver.WaitUtil(firstName, WaitType.WaitUtilVisible, 1);
            }
            catch (Exception e)
            {
                e.Message.AreEqual("Element with locator: '" + firstName + "' was not visible.");
            }
        }

        [Test]
        public void WaitUtil_WaitUtilElementIsClickableAndTimeoutIsExceed_Successfully()
        {
            By firstName = By.Id("firstNameInvalid");
            try
            {
                var element = driver.WaitUtil(firstName, WaitType.WaitUtilClickable, 1);
            }
            catch (Exception e)
            {
                e.Message.AreEqual("Element with locator: '" + firstName + "' was not clickable.");
            }
        }


        [Test]
        public void Sleep_Sleep2Seconds_TimeSleepInRightTime()
        {
            var timeBefore = DateTime.Now;
            driver.Sleep(2000);
            var timeAfter = DateTime.Now;
            int result = (int)(timeAfter - timeBefore).TotalSeconds;
            result.AreEqual(2);
        }
    }
}
