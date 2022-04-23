using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestProject.Core
{
    public class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> Pool = new();
        private static readonly object Thread = new();

        public static IWebDriver Driver
        {
            get
            {
                lock (Thread)
                {
                    return Pool.Value ??= CreateDriver();
                }
            }
        }

        private static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions { UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore };
            options.AddArguments("start-maximized"); 
            options.AddArguments("disable-infobars"); 
            options.AddArguments("--disable-extensions"); 
            options.AddArguments("--disable-gpu"); 
            options.AddArguments("--disable-dev-shm-usage"); 
            options.AddArguments("--no-sandbox");
            options.AddArguments("--headless");
            var driver = new ChromeDriver(options);
            return driver;
        }

        public static void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static void CloseDriver()
        {
            lock (Thread)
            {
                if (Pool.Value != null)
                {
                    Pool.Value.Quit();
                    Pool.Value = null;
                }
            }
        }
    }
}
