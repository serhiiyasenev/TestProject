using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static Core.DriverManager;

namespace Core
{
    public static class WaitManager 
    {
        public static IWebElement WaitForElementToBeClickable(this IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(_ =>
            {
                try { return element.Displayed && element.Enabled ? element : null; }
                catch (StaleElementReferenceException) { return null; }
            });
        }

        public static void WaitForTextInElementValue(this IWebElement element, string expectedText, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(_ => (element.GetAttribute("value") ?? string.Empty).Contains(expectedText));
        }

        public static void WaitForTextInElement(this IWebElement element, string expectedText, int seconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(_ => element.Text.Contains(expectedText));
        }

        public static void WaitForPageReady()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
