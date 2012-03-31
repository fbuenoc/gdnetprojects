using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Zone : EntityWithActive<long>, IEntityWithLifeCycle
    {
        private IList<Region> regions = new List<Region>();

        #region Properties

        public virtual Page Page
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<Region> Regions
        {
            get { return new ReadOnlyCollection<Region>(this.regions); }
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

        #region Methods

        public virtual void AddRegion(Region region)
        {
            if (!this.Regions.Contains(region))
            {
                region.Zone = this;
                this.regions.Add(region);
            }
        }

        public virtual void RemoveRegion(Region region)
        {
            if (this.Regions.Contains(region))
            {
                this.regions.Remove(region);
            }
        }

        public virtual void RemoveAllRegions()
        {
            this.regions.Clear();
        }

        #endregion

        #region Ctors

        protected Zone()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}
