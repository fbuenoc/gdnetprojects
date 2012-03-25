using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Base.Framework.System
{
    public sealed class ZoneModel : AbstractModelGeneric<Zone, long>
    {
        public ReadOnlyCollection<RegionModel> Regions
        {
            get
            {
                var listRegions = base.Entity.Regions.OrderBy(x => x.Position).Select(x => new RegionModel(x)).ToList();
                return new ReadOnlyCollection<RegionModel>(listRegions);
            }
        }

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
