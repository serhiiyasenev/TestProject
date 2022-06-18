using Core;
using OpenQA.Selenium;

namespace Business.Elements
{
    public class Button : IWrapsElement
    {
        public IWebElement WrappedElement { get; set; }

        public void Click()
        {
            WrappedElement.Click();
        }

        public string GetText()
        {
            return WrappedElement.GetValueFromControl().ToString();
        }
    }
}
