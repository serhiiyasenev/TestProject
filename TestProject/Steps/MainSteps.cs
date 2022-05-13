using Business.Pages;
using Core;

namespace TestProject.Steps
{
    public class MainSteps : BaseSteps
    {
        //test
        MainPage MainPage => new();

        public void SetValueForCalculation(string value)
        {
            MainPage.InputField.SendKeys(value);
            MainPage.InputField.WaitForTextInElementValue(value, 5);
        }

        public void Calculate()
        {
            MainPage.CalculateButton.WaitForElementToBeClickable(5);
            MainPage.CalculateButton.Click();
            WaitManager.WaitForPageReady();
        }

        public string GetResultText()
        {
            MainPage.ResultLabel.WaitForTextInElement("The factorial of", 5);
            return MainPage.ResultLabel.Text;
        }

        public string GetMessageText()
        {
            MainPage.ResultLabel.WaitForTextInElement("Please enter", 5);
            return MainPage.ResultLabel.Text;
        }
    }
}
