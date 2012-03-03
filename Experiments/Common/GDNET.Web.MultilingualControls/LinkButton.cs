using System;

using GDNET.Common.Adapters.Base;
using GDNET.Common.Base;
using GDNET.Common.Multilingual;

namespace GDNET.Web.MultilingualControls
{
    public class LinkButton : System.Web.UI.WebControls.LinkButton, IMultilingualTextControl, IMultilingualTooltipControl
    {
        public ActionType Action
        {
            get;
            set;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            MultilingualServiceHelper.TranslateControl(this);
        }

        #region IMultilingualTextControl Members

        public string TextCode
        {
            get;
            set;
        }

        #endregion

        #region IMultilingualTooltipControl Members

        public string TooltipCode
        {
            get;
            set;
        }

        #endregion
    }
}
