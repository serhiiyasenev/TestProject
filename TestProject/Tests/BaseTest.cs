using NUnit.Framework;
using NUnitProject.Core;
[assembly: Parallelizable(ParallelScope.Children)]
[assembly: LevelOfParallelism(10)]

namespace NUnitProject.Tests
{
    public class BaseTest
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
    }
}
