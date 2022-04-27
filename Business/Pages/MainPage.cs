using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Business.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='number']")]
        public IWebElement InputField { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='getFactorial']")]
        public IWebElement CalculateButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//p[@id='resultDiv']")]
        public IWebElement ResultLabel { get; private set; }
    }
}
