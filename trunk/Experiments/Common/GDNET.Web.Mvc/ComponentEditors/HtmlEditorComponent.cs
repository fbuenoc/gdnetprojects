namespace GDNET.Web.Mvc.ComponentEditors
{
    public sealed class HtmlEditorComponent : EditorComponentBase<string>
    {
        public HtmlEditorComponent()
            : base()
        {
        }

        public HtmlEditorComponent(string name, string value, bool isEnabled)
            : base(name, value, isEnabled)
        {
        }
    }
}
