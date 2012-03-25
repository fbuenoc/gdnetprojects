using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class WidgetProperty : EntityBase<long>, IEntityWithLifeCycle
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

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            protected internal set;
        }

        public virtual void ApplyDefaultSettings()
        {
        }

        #endregion

        #endregion

        #region Ctors

        protected WidgetProperty()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}
