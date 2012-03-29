using WebFramework.Common.Widgets;

namespace WebFramework.Widgets.Models.Contact
{
    public class ContactWidget : WidgetBase<ContactModel>
    {
        public override string Code
        {
            get { return "9D761767-85D3-4314-9068-D51830A1F248"; }
        }

        protected override ContactModel InitializeModel()
        {
            ContactModel result = new ContactModel(base.region);
            return result;
        }
    }
}