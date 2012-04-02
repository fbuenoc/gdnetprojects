using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Common.Framework.System
{
    public sealed class ZoneModel : ModelWithActiveBase<Zone, long>
    {
        public ReadOnlyCollection<RegionModel> Regions
        {
            get
            {
                var listRegions = base.Entity.Regions.OrderBy(x => x.Position).Select(x => new RegionModel(x)).ToList();
                return new ReadOnlyCollection<RegionModel>(listRegions);
            }
        }

        public PageModel Page
        {
            get { return new PageModel(base.Entity.Page); }
        }

        #region Properties

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

        #endregion

        #region Ctors

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

        #endregion
    }
}
