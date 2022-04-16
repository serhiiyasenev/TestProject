using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace NUnitProject.Core
{
    public class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> Pool = new();

        public static IWebDriver Driver => Pool.Value ??= CreateDriver();

        private static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions { UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore };
            options.AddArguments("start-maximized"); 
            options.AddArguments("disable-infobars"); 
            options.AddArguments("--disable-extensions"); 
            options.AddArguments("--disable-gpu"); 
            options.AddArguments("--disable-dev-shm-usage"); 
            options.AddArguments("--no-sandbox"); 
            var driver = new ChromeDriver(options);
            return driver;
        }

        public static void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void CloseDriver()
        {
            if (Pool.Value != null)
            {
                Pool.Value.Quit();
                Pool.Value = null;
            }
        }
    }
}
