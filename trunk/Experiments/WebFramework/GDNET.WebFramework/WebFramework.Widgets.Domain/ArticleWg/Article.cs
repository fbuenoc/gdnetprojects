using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Domain.ArticleWg
{
    public partial class Article : EntityBase<long>, IEntityWithLifeCycle
    {
        private IList<Region> attachedRegions = new List<Region>();

        public virtual string Title
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string FullContent
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

        protected Article()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}