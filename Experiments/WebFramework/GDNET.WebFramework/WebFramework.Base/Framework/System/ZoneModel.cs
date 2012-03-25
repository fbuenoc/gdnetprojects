using WebFramework.Base.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Base.Framework.System
{
    public sealed class ZoneModel : AbstractModelGeneric<Zone, long>
    {
        public string Code
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public ZoneModel()
            : base()
        {
        }

        public ZoneModel(Zone entity)
            : base(entity)
        {
            this.Code = entity.Code;
            this.Description = entity.Description;
        }
    }
}
