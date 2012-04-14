using System;

namespace GDNET.Web.Mvc.ComponentEditors
{
    public abstract class EditorComponentBase<T> : EditorComponentBase
    {
        public virtual T Value
        {
            get
            {
                if (this.valueObject is T)
                {
                    return (T)this.valueObject;
                }

                return (T)Convert.ChangeType(this.valueObject, typeof(T));
            }
            set { this.valueObject = value; }
        }

        public EditorComponentBase()
            : base(string.Empty, default(T), true)
        {
        }

        public EditorComponentBase(string name, T value, bool isEnabled)
            : base(name, value, isEnabled)
        {
        }
    }
}
