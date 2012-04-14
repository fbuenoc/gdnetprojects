using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public class TextBoxEditorAdapter : EditorAdapterBase<string>
    {
        public TextBoxEditorAdapter(string editorName, FormCollection collection)
            : base(editorName, collection)
        {
        }

        public override string Value
        {
            get { return base.TextContent; }
        }
    }
}
