using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public sealed class HtmlEditorAdapter : TextBoxEditorAdapter
    {
        public HtmlEditorAdapter(string editorName, FormCollection collection)
            : base(editorName, collection)
        {
        }

        public override string Value
        {
            get
            {
                return base.TextContent;
            }
        }
    }
}
