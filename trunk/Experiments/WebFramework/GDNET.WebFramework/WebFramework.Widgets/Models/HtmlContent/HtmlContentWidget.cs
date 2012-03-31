using System;
using System.Collections.Generic;
using WebFramework.Common.Widgets;

namespace WebFramework.Widgets.Models.HtmlContent
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

        public HtmlContentWidget()
            : base()
        {
            base.BeforeInstalled += HtmlContentWidget_BeforeInstalled;
            base.AfterInstalled += HtmlContentWidget_AfterInstalled;
        }

        #region Events

        void HtmlContentWidget_BeforeInstalled(object sender, EventArgs e)
        {
        }

        void HtmlContentWidget_AfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        protected override void RegisterProperties()
        {
            base.RegisterProperty(HtmlContentWidgetConstants.ContentProperty, "The content of HtmlContent widget");
            base.RegisterProperty(HtmlContentWidgetConstants.MaxVisibleLengthProperty, MaxVisibleLengthValue.ToString());

            base.RegisterProperties();
        }

        protected override HtmlContentModel InitializeModel()
        {
            HtmlContentModel result = new HtmlContentModel(base.region);
            return result;
        }
    }
}