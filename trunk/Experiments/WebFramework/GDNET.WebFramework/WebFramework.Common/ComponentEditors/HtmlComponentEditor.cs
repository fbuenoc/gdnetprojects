namespace WebFramework.Common.ComponentEditors
{
    public sealed class HtmlComponentEditor : ComponentEditorBase<string>
    {
        public HtmlComponentEditor() : base() { }
        public HtmlComponentEditor(string name, string value) : base(name, value) { }
    }
}
