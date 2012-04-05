namespace WebFramework.Common.ComponentEditors
{
    public sealed class TextBoxComponentEditor : ComponentEditorBase<string>
    {
        public TextBoxComponentEditor() : base() { }
        public TextBoxComponentEditor(string name, string value) : base(name, value) { }
    }
}
