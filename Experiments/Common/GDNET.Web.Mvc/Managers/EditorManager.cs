using System;
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

        public void RenderEditorComponent(Editors editor, string name, string value, bool isEnabled)
        {
            EditorComponentBase editorModel = null;

            switch (editor)
            {
                case Editors.HtmlEditor:
                    editorModel = new HtmlEditorComponent(name, value, isEnabled);
                    break;
                case Editors.NumberEditor:
                    editorModel = new NumberEditorComponent(name, Convert.ToDouble(value), isEnabled);
                    break;
                case Editors.TextAreaEditor:
                    editorModel = new TextAreaEditorComponent(name, value, isEnabled);
                    break;
                case Editors.TextBoxEditor:
                    editorModel = new TextBoxEditorComponent(name, value, isEnabled);
                    break;
            }

            this.RenderEditorComponent(editor, editorModel);
        }
    }
}
