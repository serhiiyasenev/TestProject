﻿using NUnit.Framework;
using TestProject.Core;

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
            DriverManager.CloseDriver();
        }

        [OneTimeTearDown]
        public void RunFinalize()
        {
            Helpers.KillAllProcesses("chromedriver");
            Helpers.KillAllProcesses("geckodriver");
        }
    }
}
