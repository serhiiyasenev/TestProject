using Core;
using Core.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using static NUnit.Framework.TestContext;

namespace TestProject.Tests.Base
{
    public class BaseTestUI : BaseTest
    {
        [SetUp]
        public void TestInitialize()
        {
            DriverManager.OpenUrl(Urls.Base);
        }

        [TearDown]
        public void TestFinalize()
        {
            if (CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)DriverManager.Driver).GetScreenshot();
                var fileName = Path.Combine(Environment.CurrentDirectory, $"{CurrentContext.Test.MethodName}_{Context.Environment}_{DateTime.UtcNow.Ticks}.jpg");
                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                AddTestAttachment(fileName);
            }
            DriverManager.CloseDriver();
        }

        [OneTimeTearDown]
        public void RunFinalize()
        {
            ProcessHelper.KillAllProcesses("chromedriver");
            ProcessHelper.KillAllProcesses("geckodriver");
        }
    }
}
