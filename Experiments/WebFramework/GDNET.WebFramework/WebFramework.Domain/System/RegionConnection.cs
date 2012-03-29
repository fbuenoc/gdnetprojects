using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.System
{
    public partial class RegionConnection : EntityBase<long>
    {
        public virtual Region From
        {
            get;
            protected internal set;
        }

        public virtual Region To
        {
            get;
            protected internal set;
        }

        public virtual string Action
        {
            get;
            set;
        }

        protected internal RegionConnection() { }
    }
}
