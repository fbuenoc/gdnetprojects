using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Web.Mvc.ComponentEditors;

namespace GDNET.Web.Mvc.Helpers
{
    public sealed class EditorManager
    {
        private HtmlHelper html;

        public EditorManager(HtmlHelper html)
        {
            this.html = html;
        }

        public void RenderEditorComponent(Editors editor, EditorComponentBase editorModel)
        {
            if (editor != Editors.None)
            {
                string editorViewName = string.Format("EditorComponents/{0}", editor.ToString());
                this.html.RenderPartial(editorViewName, editorModel);
            }
        }
    }
}
