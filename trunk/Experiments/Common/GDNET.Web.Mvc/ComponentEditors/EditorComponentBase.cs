namespace GDNET.Web.Mvc.ComponentEditors
{
    public abstract class EditorComponentBase
    {
        protected object valueObject = null;

        public string Name
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            protected set;
        }

        public EditorComponentBase(string name, object value, bool isEnabled)
        {
            this.Name = name;
            this.valueObject = value;
            this.IsEnabled = isEnabled;
        }
    }
}
