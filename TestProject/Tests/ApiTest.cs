using NUnit.Framework;
using NUnitProject.Models;
using System.Threading.Tasks;
using static NUnitProject.Core.Helpers;

namespace NUnitProject.Tests
{
    [TestFixture]
    class ApiTest 
    {
        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(21, "51090942171709440000")]
        public async Task FactorialCalculatorPositive(int enteredValue, string calculatedValue = null)
        {
            // Arrange
            var expectedResult = calculatedValue ??= GetFactorial(enteredValue).ToString();

            // Act
            var response = await SendCalculateAsync(enteredValue.ToString(), "factorial");
            var actualResult = DeserializeObjectAsync<AnswerModel>(response).Answer;

            // Assert
            Assert.AreEqual(expectedResult, actualResult, $"Actual result of factorial calculation '{actualResult}' is not equal to expected '{calculatedValue}'");
        }

        [Test]
        [TestCase("-1", "Use positive values")]
        [TestCase("xxx", "Please enter an integer")]
        [TestCase("33y", "Please enter an integer")]
        [TestCase("1.5", "Please enter an integer")]
        public async Task FactorialCalculatorNegative(string enteredValue, string expectedMessage)
        {
            // Act
            var response = await SendCalculateAsync(enteredValue, "factorial");
            var actualResult = DeserializeObjectAsync<AnswerModel>(response).Answer;

            // Assert
            Assert.AreEqual(expectedMessage, actualResult, "Result of preliminary checks before settlements is not equal to expected");
        }
    }
}