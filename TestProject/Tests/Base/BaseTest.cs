using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Children)]
[assembly: LevelOfParallelism(10)]

namespace TestProject.Tests.Base
{
    public class BaseTest
    {

        public BaseTest()
        {

        }

    }
}