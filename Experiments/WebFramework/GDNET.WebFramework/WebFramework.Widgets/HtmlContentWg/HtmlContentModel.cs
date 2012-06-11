using WebFramework.Common.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Widgets.HtmlContentWg.Controllers;

namespace WebFramework.Widgets.HtmlContentWg
{
    public sealed class HtmlContentModel : WidgetModelBase
    {
        public HtmlContentModel(RegionModel regionModel)
            : base(regionModel)
        {
            this.HtmlContent = base.GetPropertyValue<string>(HtmlContentWidgetConstants.ContentProperty);
        }

        public string HtmlContent
        {
            get;
            set;
        }

        public string HtmlContentCalculated
        {
            get
            {
                if (this.IsOverWeight)
                {
                    int tempPosition = base.GetPropertyValue<int>(HtmlContentWidgetConstants.MaxVisibleLengthProperty);
                    while (tempPosition < this.HtmlContent.Length)
                    {
                        var temp = this.HtmlContent.Substring(tempPosition, 1);
                        if (temp == "." || temp == "!" || temp == "?" || temp == " ")
                        {
                            break;
                        }
                        tempPosition += 1;
                    }
                    return this.HtmlContent.Substring(0, tempPosition);
                }

                return this.HtmlContent;
            }
        }

        public bool IsOverWeight
        {
            get
            {
                int maxVisibleLength = base.GetPropertyValue<int>(HtmlContentWidgetConstants.MaxVisibleLengthProperty);
                if (!string.IsNullOrEmpty(this.HtmlContent) && this.HtmlContent.Length > maxVisibleLength)
                {
                    return true;
                }
                return false;
            }
        }

        public override bool CanManage
        {
            get
            {
                return FrameworkServices.Authorization.ActionIsAllowedForUser(typeof(AdminController).FullName, AdminController.ActionIndex);
            }
        }
    }
}