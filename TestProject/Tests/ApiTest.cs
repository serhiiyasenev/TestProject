using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Tests.Base;
using static TestProject.Core.Helpers;

namespace TestProject.Tests
{
    [TestFixture]
    class ApiTest : BaseTestAPI
    {
        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(21, "51090942171709440000")]
        public async Task FactorialCalculatorPositive(int enteredValue, string calculatedValue = null)
        {
            // Arrange
            var expectedResult = calculatedValue ??= GetFactorial(enteredValue).ToString();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("number", $"{enteredValue}")
            });

            // Act
            var response = await HttpClient.SendPostAsync(content, "factorial");
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
            // Arrange
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("number", $"{enteredValue}")
            });

            // Act
            var response = await HttpClient.SendPostAsync(content, "factorial");
            var actualResult = DeserializeObjectAsync<AnswerModel>(response).Answer;

            // Assert
            Assert.AreEqual(expectedMessage, actualResult, "Result of preliminary checks before settlements is not equal to expected");
        }
    }
}