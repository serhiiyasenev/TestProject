﻿using Core.Enums;
using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using static Core.Enums.Browser;

namespace Core
{
    public class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> Pool = new();
        
        public static IWebDriver Driver => Pool.Value ??= GetWebDriver(Context.Browser);

        private static IWebDriver GetWebDriver(Browser browser)
        {
            Logger.LogInformation($"GetWebDriver for Browser '{browser}'");

            return browser switch
            {
                Chrome => CreateChromeDriver(),
                Firefox => CreateFirefoxDriver(),
                //Edge => TBD,
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, "Unsupported browser")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            Logger.LogInformation($"Context.BrowserHeadless is '{Context.BrowserHeadless}'");

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
            if (Context.BrowserHeadless) options.AddArgument("--headless");
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
            if (Context.BrowserHeadless) options.AddArgument("--headless");
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
            if (Pool.Value != null)
            {
                Pool.Value.Quit();
                Pool.Value = null;
            }
        }
    }
}
