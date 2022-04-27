using Core;
using SeleniumExtras.PageObjects;

namespace Business.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverManager.Driver, this);
        }
    }
}
