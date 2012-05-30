using System.Collections.Generic;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Constants;

namespace WebFramework.Widgets.HtmlContentWg
{
    public class HtmlContentWidget : WidgetBase<HtmlContentModel>
    {
        private const int MaxVisibleLengthValue = 1000;

        public override string Code
        {
            get { return "F3E4B514-874D-45C0-88B9-95438E2A6F65"; }
        }

        public override IList<WidgetAction> Actions
        {
            get
            {
                var actions = base.Actions;
                actions.Add(new WidgetAction(WidgetActions.Detail));

                return actions;
            }
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperty(HtmlContentWidgetConstants.ContentProperty, "The content of HtmlContent widget", ListValueConstants.ContentDataTypes.TextHtmlEditor);
            base.RegisterProperty(HtmlContentWidgetConstants.MaxVisibleLengthProperty, MaxVisibleLengthValue.ToString(), ListValueConstants.ContentDataTypes.NumberNormalNumber);

            base.RegisterProperties();
        }
    }
}