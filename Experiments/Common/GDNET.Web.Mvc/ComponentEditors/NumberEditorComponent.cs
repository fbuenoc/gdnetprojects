namespace GDNET.Web.Mvc.ComponentEditors
{
    public sealed class NumberEditorComponent : EditorComponentBase<double?>
    {
        public NumberEditorComponent()
            : base()
        {
        }

        public NumberEditorComponent(string name, double? value, bool isEnabled)
            : base(name, value, isEnabled)
        {
        }
    }
}
