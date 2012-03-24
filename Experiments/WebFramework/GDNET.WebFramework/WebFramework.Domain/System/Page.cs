using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Page : EntityBase<long>, IEntityWithLifeCycle
    {
        #region Fields

        private IList<Zone> zones = new List<Zone>();

        #endregion

        #region Properties

        public virtual Application Application
        {
            get;
            protected internal set;
        }

        public virtual Culture Culture
        {
            get;
            protected internal set;
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

        public virtual string Keyword
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<Zone> Zones
        {
            get { return new ReadOnlyCollection<Zone>(zones); }
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

        public virtual void AddZone(Zone zone)
        {
            if (!this.Zones.Contains(zone))
            {
                this.zones.Add(zone);
            }
        }

        public virtual void RemoveZone(Zone zone)
        {
            if (this.Zones.Contains(zone))
            {
                this.zones.Remove(zone);
            }
        }

        public virtual void RemoveAllZones()
        {
            this.zones.Clear();
        }

        #endregion

        #region Ctors

        protected Page() { }

        #endregion
    }
}
