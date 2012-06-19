using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Domain.System;
using WebFramework.Widgets.Daskboard.Base;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public sealed class ZoneModel : ModelEntityWithLifeCycleBase<Zone, long>
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
            get
            {
                if (base.Entity != null && base.Entity.Page != null)
                {
                    return new PageModel(base.Entity.Page);
                }

                return default(PageModel);
            }
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
