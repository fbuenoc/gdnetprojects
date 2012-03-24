using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.System
{
    public partial class WidgetProperty : EntityBase<long>
    {
        #region Properties

        public virtual Widget Widget
        {
            get;
            protected internal set;
        }

        public virtual string Code
        {
            get;
            protected internal set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        #endregion

        protected WidgetProperty() { }
    }
}
