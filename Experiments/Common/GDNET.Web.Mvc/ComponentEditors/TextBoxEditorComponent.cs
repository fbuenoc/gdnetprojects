namespace GDNET.Web.Mvc.ComponentEditors
{
    public sealed class TextBoxEditorComponent : EditorComponentBase<string>
    {
        public TextBoxEditorComponent()
            : base()
        {
        }

        public TextBoxEditorComponent(string name, string value, bool isEnabled)
            : base(name, value, isEnabled)
        {
        }
    }
}
