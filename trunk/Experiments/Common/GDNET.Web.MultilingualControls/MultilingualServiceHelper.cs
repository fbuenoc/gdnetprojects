using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Common.Base;
using GDNET.Common.Base.Services;
using GDNET.Common.DesignByContract;
using GDNET.Common.Multilingual;

namespace GDNET.Web.MultilingualControls
{
    public static class MultilingualServiceHelper
    {
        public static IMultilingualService Service
        {
            get;
            private set;
        }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="service"></param>
        public static void Initialize(IMultilingualService service)
        {
            Service = service;
        }

        /// <summary>
        /// Translate from text from code of control
        /// </summary>
        /// <param name="control"></param>
        public static void TranslateControl(Control control)
        {
            ThrowException.ArgumentNullException(control, "control", "Invalid control.");
            ThrowException.InvalidOperationExceptionIfNull(Service, "No multilingual service available.");

            if ((control is WebControl) && (control is IMultilingualTooltipControl))
            {
                string tooltipCode = ((IMultilingualTooltipControl)control).TooltipCode;
                ((WebControl)control).ToolTip = VerifyTranslation(tooltipCode, ((WebControl)control).ToolTip);
            }

            if (control is IMultilingualTextControl)
            {
                string textCode = ((IMultilingualTextControl)control).TextCode;
                if (control is ITextControl)
                {
                    ((ITextControl)control).Text = VerifyTranslation(textCode, ((ITextControl)control).Text);
                }
                if (control is IButtonControl)
                {
                    ((IButtonControl)control).Text = VerifyTranslation(textCode, ((IButtonControl)control).Text);
                }
            }
        }

        /// <summary>
        /// Get correct translation from its code, or use default value if any wrong.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="valueIfKO"></param>
        /// <returns></returns>
        private static string VerifyTranslation(string code, string valueIfKO)
        {
            if (string.IsNullOrEmpty(code))
            {
                return valueIfKO;
            }

            string translationText = Service.GetTranslation(code);
            return (translationText == string.Format("!{0}!", code)) ? valueIfKO : translationText;
        }
    }
}
