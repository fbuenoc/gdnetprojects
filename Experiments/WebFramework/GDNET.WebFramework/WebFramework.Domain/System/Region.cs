using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.System
{
    public partial class Region : EntityBase<long>, IEntityWithLifeCycle
    {
        private IList<RegionSetting> settings = new List<RegionSetting>();

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

        public virtual int Position
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<RegionSetting> Settings
        {
            get { return new ReadOnlyCollection<RegionSetting>(this.settings); }
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

        #endregion

        #region Ctors

        protected Region() { }

        #endregion
    }
}
