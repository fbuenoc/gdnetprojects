using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Region : EntityWithActiveBase<long>, IEntityWithLifeCycle
    {
        private IList<RegionSetting> settings = new List<RegionSetting>();
        private IList<RegionConnection> regionConnections = new List<RegionConnection>();

        #region Properties

        public virtual Widget Widget
        {
            get;
            protected internal set;
        }

        public virtual Zone Zone
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

        public virtual int? Position
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<RegionSetting> Settings
        {
            get { return new ReadOnlyCollection<RegionSetting>(this.settings); }
        }

        public virtual ReadOnlyCollection<RegionConnection> RegionConnections
        {
            get { return new ReadOnlyCollection<RegionConnection>(this.regionConnections); }
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

        public virtual void AddSetting(RegionSetting setting)
        {
            if (!this.Settings.Contains(setting))
            {
                setting.Region = this;
                this.settings.Add(setting);
            }
        }

        public virtual void RemoveSetting(RegionSetting setting)
        {
            if (this.Settings.Contains(setting))
            {
                this.settings.Remove(setting);
            }
        }

        public virtual void RemoveAllSettings()
        {
            this.settings.Clear();
        }

        public virtual void AddConnection(RegionConnection connection)
        {
            if (!this.RegionConnections.Contains(connection))
            {
                connection.From = this;
                this.regionConnections.Add(connection);
            }
        }

        public virtual void RemoveConnection(RegionConnection connection)
        {
            if (this.RegionConnections.Contains(connection))
            {
                this.regionConnections.Remove(connection);
            }
        }

        public virtual void RemoveAllConnection()
        {
            this.regionConnections.Clear();
        }

        #endregion

        #region Ctors

        protected Region()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

        #endregion
    }
}
