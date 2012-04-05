using WebFramework.Common.Widgets;
using WebFramework.Domain.Constants;

namespace WebFramework.Widgets.Models.Contact
{
    public class ContactWidget : WidgetBase<ContactModel>
    {
        public override string Code
        {
            get { return "9D761767-85D3-4314-9068-D51830A1F248"; }
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
            base.RegisterProperty(WidgetBaseConstants.PropertyPageSize, WidgetBaseConstants.DefaultPageSize.ToString(), ListValueConstants.ContentDataTypes.NumberNormalNumber);
        }

        protected override ContactModel InitializeModel()
        {
            ContactModel result = new ContactModel(base.region);
            return result;
        }
    }
}