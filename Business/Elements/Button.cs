using Core;

namespace Business.Elements
{
    public class Button : Element
    {
        public override void Click()
        {
            WrappedElement.Click();
        }

        public string GetText()
        {
            return WrappedElement.GetValueFromControl().ToString();
        }
    }
}
