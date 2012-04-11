using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Extensions;
using GDNET.Web.Mvc;
using GDNET.Web.Mvc.ComponentEditors;
using Telerik.Web.Mvc.UI;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.UI.Helpers
{
    public class EditorFactory
    {
        private HtmlHelper htmlHelper;

        public EditorFactory(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public MvcHtmlString RenderTextEditor(ContentItemAttributeValueModel valueModel)
        {
            return this.RenderTextEditor(valueModel, null);
        }

        public void RenderEditorComponent(ContentItemAttributeValueModel attributeValueModel, bool isEnabled)
        {
            switch (attributeValueModel.ContentAttribute.DataType.Name)
            {
                case ListValueConstants.ContentDataTypes.TextTextArea:
                    {
                        var editorModel = new TextAreaEditorComponent(attributeValueModel.ContentAttribute.Code, attributeValueModel.Value, isEnabled);
                        this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, editorModel);
                    }
                    break;
                case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                    {
                        var editorModel = new HtmlEditorComponent(attributeValueModel.ContentAttribute.Code, attributeValueModel.Value, isEnabled);
                        this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, editorModel);
                    }
                    break;
                case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                    {
                        var doubleValue = attributeValueModel.Value.ToDouble();
                        var editorModel = new NumberEditorComponent(attributeValueModel.ContentAttribute.Code, doubleValue, isEnabled);
                        this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.NumberEditor, editorModel);
                    }
                    break;
                case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                    {
                        var editorModel = new TextBoxEditorComponent(attributeValueModel.ContentAttribute.Code, attributeValueModel.Value, isEnabled);
                        this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, editorModel);
                    }
                    break;
            }
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

                    case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                        {
                            double value = double.Parse(valueModel.Value);
                            string inputComponent = this.htmlHelper.Telerik().NumericTextBox().Name(inputName).Value(value).HtmlAttributes(htmlAttributes).ToHtmlString();
                            return MvcHtmlString.Create(inputComponent);
                        }

                    case ListValueConstants.ContentDataTypes.NumberPercentage:
                        {
                            double value = double.Parse(valueModel.Value);
                            string inputComponent = this.htmlHelper.Telerik().PercentTextBox().Name(inputName).Value(value).HtmlAttributes(htmlAttributes).ToHtmlString();
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
