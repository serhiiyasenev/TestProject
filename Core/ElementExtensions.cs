using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using static Core.DriverManager;

namespace Core
{
    public static class ElementExtensions
    {
        public static void DragAndDrop(this IWebElement source, Point location)
        {
            var offsetX = location.X - source.Location.X;
            var offsetY = location.Y - source.Location.Y;
            new Actions(Driver).DragAndDropToOffset(source, offsetX, offsetY).Build().Perform();
        }

        public static void DragAndDrop(this IWebElement source, IWebElement target)
        {
            new Actions(Driver).DragAndDrop(source, target).Build().Perform();
        }

        public static bool IsDisabled(this IWebElement element)
        {
            var disabled = element.GetAttribute("disabled") == "true" || 
                           element.GetAttribute("readonly") == "true" || 
                           element.GetAttribute("disabled") == "disabled" || 
                           element.GetAttribute("readonly") == "readonly";

            return disabled;
        }

        public static bool IsElementVisible(this IWebElement element)
        {
            var windowHeight = double.Parse(JavaScriptExecutor.ExecuteScript("return window.innerHeight;").ToString());
            var elementBottom = double.Parse(JavaScriptExecutor.ExecuteScript("return arguments[0].getBoundingClientRect().bottom;", element).ToString());
            var elementTop = double.Parse(JavaScriptExecutor.ExecuteScript("return arguments[0].getBoundingClientRect().top;", element).ToString());
            var isElementInViewPort = elementBottom > 0 && windowHeight - elementTop > 0;
            return isElementInViewPort;
        }

        public static void SetValueToControl(this IWebElement control, string value)
        {
            JavaScriptExecutor.ExecuteScript($"arguments[0].setAttribute('value', '{value}')", control);
        }

        public static void ScrollIntoView(this IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static void JsClick(this IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public static IWebElement GetChildCheckbox(this IWebElement element)
        {
            return element.FindElement(By.TagName("input"));
        }

        public static object GetValueFromControl(this IWebElement element)
        {
            return JavaScriptExecutor.ExecuteScript("return arguments[0].value;", element);
        }
    }
}