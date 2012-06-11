using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Common.Framework.System
{
    public class PageModel : ModelEntityWithLifeCycleBase<Page, long>, IModelWithLifeCycle
    {
        #region Properties

        /// <summary>
        /// Convert all Zone to ZoneModel
        /// </summary>
        public ReadOnlyCollection<ZoneModel> ZoneModels
        {
            get
            {
                var zoneModels = base.Entity.Zones.Select(x => new ZoneModel(x)).ToList();
                return new ReadOnlyCollection<ZoneModel>(zoneModels);
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Keyword
        {
            get;
            set;
        }

        public string UniqueName
        {
            get;
            set;
        }

        public string AdministerUrl
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public PageModel()
            : base()
        {
        }

        public PageModel(Page entity)
            : base(entity)
        {
            this.Name = entity.Name;
            this.UniqueName = entity.UniqueName;
            this.Description = entity.Description;
            this.Keyword = entity.Keyword;
        }

        #endregion
    }
}
