using Business.Elements;
using OpenQA.Selenium;
using Core;

namespace Business.Pages
{
    public class MainPage : BasePage
    {
        public IWebElement InputField => DriverManager.Driver.FindElement(By.Id("number"));

        public Button CalculateButton => new Button
        {
            WrappedElement = DriverManager.Driver.FindElement(By.Id("getFactorial"))
        };

        public IWebElement ResultLabel => DriverManager.Driver.FindElement(By.Id("resultDiv"));
    }
}
