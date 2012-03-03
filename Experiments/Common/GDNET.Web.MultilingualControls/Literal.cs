using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Base;
using GDNET.Common.Multilingual;

namespace GDNET.Web.MultilingualControls
{
    public class Literal : System.Web.UI.WebControls.Literal, IMultilingualTextControl
    {
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
    }
}
