using SeleniumExtras.PageObjects;
using TestProject.Core;

namespace TestProject.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverManager.Driver, this);
        }
    }
}
