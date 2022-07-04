using Business.Elements.Base;
using Core;

namespace Business.Elements
{
    public class Button : Element, IGetable
    {
        public override void Click()
        {
            WrappedElement.Click();
        }

        public object GetValue()
        {
            return WrappedElement.GetValueFromControl();
        }
    }
}
