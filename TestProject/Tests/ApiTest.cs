using Business.Models;
using Core;
using NUnit.Framework;
using System.Threading.Tasks;
using TestProject.Tests.Base;
using static Core.Utilities.Helpers;

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
            var content = HttpClientManager.CreateContent(enteredValue.ToString());

            // Act
            var response = await HttpClient.PostAsync("factorial", content);
            var actualResult = await HttpClient.DeserializeObjectAsync<AnswerModel>(response);

            // Assert
            Assert.AreEqual(expectedResult, actualResult.Answer, $"Actual result of factorial calculation '{actualResult}' is not equal to expected '{calculatedValue}'");
        }

        [Test]
        [TestCase("-1", "Use positive values")]
        [TestCase("xxx", "Please enter an integer")]
        [TestCase("33y", "Please enter an integer")]
        [TestCase("1.5", "Please enter an integer")]
        public async Task FactorialCalculatorNegative(string enteredValue, string expectedMessage)
        {
            // Arrange
            var content = HttpClientManager.CreateContent(enteredValue);

            // Act
            var response = await HttpClient.PostAsync("factorial", content);
            var actualResult = await HttpClient.DeserializeObjectAsync<AnswerModel>(response);

            // Assert
            Assert.AreEqual(expectedMessage, actualResult.Answer, "Result of preliminary checks before settlements is not equal to expected");
        }

        
    }
}