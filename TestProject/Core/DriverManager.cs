﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
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
                    Console.WriteLine("=====================================");
                    Console.WriteLine($"Environment.GetEnvironmentVariable RESULT is '{Environment.GetEnvironmentVariable("Browser")}'");
                    Console.WriteLine("=====================================");
                    var browser = Environment.GetEnvironmentVariable("Browser") ?? "Chrome";
                    return Pool.Value ??= GetWebDriver(browser);
                }
            }
        }

        private static IWebDriver GetWebDriver(string browser)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"GetWebDriver for Browser '{browser}'");
            Console.WriteLine("=====================================");

            return browser switch
            {
                "Chrome"  => CreateChromeDriver(),
                "Firefox" => CreateFirefoxDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, "Unsupported browser")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions { UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore };
            options.AddArgument("--disable-web-security");
            options.AddArgument("start-maximized"); 
            options.AddArgument("disable-infobars"); 
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-gpu"); 
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            var driver = new ChromeDriver(options);
            return driver;
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions { UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore };
            options.AddArgument("--disable-web-security");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--no-sandbox");
            options.AddArguments("--headless");
            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
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
