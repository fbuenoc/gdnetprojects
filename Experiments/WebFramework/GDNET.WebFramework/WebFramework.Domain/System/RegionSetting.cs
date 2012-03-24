using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.System
{
    public partial class RegionSetting : EntityBase<long>
    {
        #region Properties

        public virtual Region Region
        {
            get;
            protected internal set;
        }

        public virtual WidgetProperty WidgetProperty
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

        protected RegionSetting() { }
    }
}
