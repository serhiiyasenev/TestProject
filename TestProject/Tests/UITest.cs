using NUnit.Framework;
using TestProject.Core;
using TestProject.Steps;
using TestProject.Tests.Base;
using static TestProject.Core.Helpers;

namespace TestProject.Tests
{
    [TestFixture]
    class UITest : BaseTestUI
    {
        private readonly MainSteps _mainSteps;

        public UITest()
        {
            _mainSteps = new MainSteps();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(21, "51090942171709440000")]
        [TestCase(101, "9.42594775983836e+159")]
        public void FactorialCalculatorPositive(int enteredValue, string calculatedValue = null)
        {
            Logger.LogInformation($"FactorialCalculatorPositive `{enteredValue}` started");

            // Arrange
            _mainSteps.SetValueForCalculation(enteredValue.ToString());
            calculatedValue ??= GetFactorial(enteredValue).ToString();
            var expectedResult = $"The factorial of {enteredValue} is: {calculatedValue}";

            // Act
            _mainSteps.Calculate();

            // Assert
            var actualResult = _mainSteps.GetResultText();
            Assert.AreEqual(expectedResult, actualResult, $"Actual result of factorial calculation '{actualResult}' is not equal to expected '{calculatedValue}'");
        }

        [Test]
        [TestCase("-1", "Use positive values")]
        [TestCase("xxx", "Please enter an integer")]
        [TestCase("33y", "Please enter an integer")]
        [TestCase("1.5", "Please enter an integer")]
        public void FactorialCalculatorNegative(string enteredValue, string expectedMessage)
        {
            // Arrange
            _mainSteps.SetValueForCalculation(enteredValue);

            // Act
            _mainSteps.Calculate();

            // Assert
            var actualResult = _mainSteps.GetMessageText();
            Assert.AreEqual(expectedMessage, actualResult, "Result of preliminary checks before settlements is not equal to expected");
        }
    }
}