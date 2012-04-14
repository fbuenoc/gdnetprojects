using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public class TextAreaEditorAdapter : EditorAdapterBase<string>
    {
        public TextAreaEditorAdapter(string editorName, FormCollection collection)
            : base(editorName, collection)
        {
        }

        public override string Value
        {
            get { return base.TextContent; }
        }
    }
}
