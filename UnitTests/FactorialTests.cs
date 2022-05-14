using Core.Utilities;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class FactorialTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(19, 109641728)]
        public void FactorialCalculation(int input, int expectedResult)
        {
            var actualResult = MathHelper.GetFactorial(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-999999999)]
        public void FactorialThrowsArgumentException(int input)
        {
            Assert.Throws<ArgumentException>(() => MathHelper.GetFactorial(input));
        }

        [Test]
        [TestCase(20)]
        public void FactorialThrowsOverflowException(int input)
        {
            Assert.Throws<OverflowException>(() => MathHelper.GetFactorial(input));
        }
    }
}