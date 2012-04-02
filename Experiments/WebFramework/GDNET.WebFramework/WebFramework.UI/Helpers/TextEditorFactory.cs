using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Telerik.Web.Mvc.UI;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.UI.Helpers
{
    public class TextEditorFactory
    {
        private HtmlHelper htmlHelper;

        public TextEditorFactory(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public MvcHtmlString RenderTextEditor(ContentItemAttributeValueModel valueModel)
        {
            return this.RenderTextEditor(valueModel, null);
        }

        public MvcHtmlString RenderTextEditor(ContentItemAttributeValueModel valueModel, object htmlAttributes)
        {
            if (valueModel != null)
            {
                string htmlValue = HttpUtility.HtmlDecode(valueModel.Value);
                string inputName = valueModel.ContentAttribute.Name;

                switch (valueModel.DataTypeName)
                {
                    case ListValueConstants.ContentDataTypes.TextTextArea:
                        {
                            return this.htmlHelper.TextArea(inputName, htmlValue, htmlAttributes);
                        }

                    case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                        {
                            return this.htmlHelper.TextBox(inputName, htmlValue, htmlAttributes);
                        }

                    case ListValueConstants.ContentDataTypes.NumberPercentage:
                        {
                            double value = double.Parse(valueModel.Value);
                            string inputComponent = this.htmlHelper.Telerik().NumericTextBox().Name(inputName).Value(value).HtmlAttributes(htmlAttributes).ToHtmlString();
                            return MvcHtmlString.Create(inputComponent);
                        }

                    case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                        {
                            string htmlEditor = this.htmlHelper.Telerik().Editor().Name(inputName).Value(htmlValue).HtmlAttributes(htmlAttributes).ToHtmlString();
                            return MvcHtmlString.Create(htmlEditor);
                        }
                }
            }

            return MvcHtmlString.Create(string.Empty);
        }
    }
}
