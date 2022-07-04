using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Business.Elements
{
    public class Element : IWebElement, IWrapsElement
    {
        public IWebElement WrappedElement { get; set; }

        public string TagName => WrappedElement.TagName;
        public string Text => WrappedElement.Text;
        public bool Enabled => WrappedElement.Enabled;
        public bool Selected => WrappedElement.Selected;
        public Point Location => WrappedElement.Location;
        public Size Size => WrappedElement.Size;
        public bool Displayed => WrappedElement.Displayed;

        public IWebElement FindElement(By @by)
        {
            return WrappedElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
           return WrappedElement.FindElements(by);
        }

        public void Clear()
        {
            WrappedElement.Clear();
        }

        public void SendKeys(string text)
        {
            WrappedElement.SendKeys(text);
        }

        public void Submit()
        {
            WrappedElement.Submit();
        }

        public virtual void Click()
        {
            WrappedElement.Click();
        }

        public string GetAttribute(string attributeName)
        {
           return WrappedElement.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
           return WrappedElement.GetDomAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
           return WrappedElement.GetDomProperty(propertyName);
        }

        public string GetDomProperty(string propertyName)
        {
           return WrappedElement.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return WrappedElement.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return WrappedElement.GetShadowRoot();
        }
    }
}
