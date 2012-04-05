using System;

namespace WebFramework.Common.ComponentEditors
{
    public abstract class ComponentEditorBase<T>
    {
        private object valueObject = default(T);

        public string Name
        {
            get;
            set;
        }

        public virtual T Value
        {
            get { return (T)Convert.ChangeType(this.valueObject, typeof(T)); }
            set { this.valueObject = value; }
        }

        public ComponentEditorBase()
            : this(string.Empty, default(T))
        {
        }

        public ComponentEditorBase(string name, T value)
        {
            this.Name = name;
            this.valueObject = value;
        }
    }
}
