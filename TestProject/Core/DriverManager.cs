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
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
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
