using Core;
using Core.Utilities;
using NUnit.Framework;

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
            ProcessHelper.KillAllProcesses("chromedriver");
            ProcessHelper.KillAllProcesses("geckodriver");
        }
    }
}
