using System.Collections.Generic;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Base.Framework.System
{
    public sealed class PageModel : AbstractModelGeneric<Page, long>
    {
        private IList<ZoneModel> zoneModels = null;

        public IList<ZoneModel> ZoneModels
        {
            get
            {
                if (this.zoneModels == null)
                {
                    this.zoneModels = new List<ZoneModel>();
                }

                foreach (var zone in base.Entity.Zones)
                {
                    this.ZoneModels.Add(new ZoneModel(zone));
                }

                return zoneModels;
            }
        }

        #region Ctors

        public PageModel()
            : base()
        {
        }

        public PageModel(Page entity)
            : base(entity)
        {
        }

        #endregion
    }
}
