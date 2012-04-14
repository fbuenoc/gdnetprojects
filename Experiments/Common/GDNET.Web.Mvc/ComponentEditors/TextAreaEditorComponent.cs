namespace GDNET.Web.Mvc.ComponentEditors
{
    public sealed class TextAreaEditorComponent : EditorComponentBase<string>
    {
        public TextAreaEditorComponent()
            : base()
        {
        }

        public TextAreaEditorComponent(string name, string value, bool isEnabled)
            : base(name, value, isEnabled)
        {
        }
    }
}
