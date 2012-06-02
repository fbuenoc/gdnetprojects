using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Domain.FileWg
{
    public partial class FileContent : EntityBase<long>, IEntityWithLifeCycle
    {
        private IList<Region> attachedRegions = new List<Region>();

        public virtual ListValue Type
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Base64Content
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<Region> AttachedRegions
        {
            get { return new ReadOnlyCollection<Region>(this.attachedRegions); }
        }

        public virtual void AddRegion(Region region)
        {
            if (!this.attachedRegions.Contains(region))
            {
                this.attachedRegions.Add(region);
            }
        }

        public virtual void RemoveRegion(Region region)
        {
            if (this.attachedRegions.Contains(region))
            {
                this.attachedRegions.Remove(region);
            }
        }

        public virtual void RemoveAllRegions()
        {
            this.attachedRegions.Clear();
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

        #region Ctors

        protected FileContent()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}
