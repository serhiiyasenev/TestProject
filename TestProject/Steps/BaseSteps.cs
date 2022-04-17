using OpenQA.Selenium.Support.UI;
using System;
using static TestProject.Core.DriverManager;

namespace TestProject.Steps
{
    public class BaseSteps
    {
        protected WebDriverWait Wait;

        public BaseSteps()
        {
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        } 
    }
}

