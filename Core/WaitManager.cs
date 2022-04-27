using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static Core.DriverManager;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core
{
    public static class WaitManager 
    {
        public static IWebElement WaitForElementToBeClickable(this IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ElementToBeClickable(element));
        }

        public static void WaitForTextInElementValue(this IWebElement element, string expectedText, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(TextToBePresentInElementValue(element, expectedText));
        }

        public static void WaitForTextInElement(this IWebElement element, string expectedText, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(TextToBePresentInElement(element, expectedText));
        }

        public static void WaitForPageReady()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
