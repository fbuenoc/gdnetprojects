using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Extensions;
using WebFramework.Common.Framework.System;

namespace WebFramework.Common.Widgets
{
    public abstract class WidgetModelBase
    {
        private RegionModel regionModel;

        public WidgetModelBase(RegionModel regionModel)
        {
            this.regionModel = regionModel;

            this.Name = regionModel.Name;
            this.Description = regionModel.Description;
        }

        #region Properties

        public ReadOnlyCollection<KeyValuePair<WidgetPropertyModel, string>> Properties
        {
            get { return this.regionModel.Properties; }
        }

        public long IdRegion
        {
            get { return this.regionModel.Id; }
        }

        public long? IdZone
        {
            get
            {
                if (this.regionModel.Zone != null)
                {
                    return this.regionModel.Zone.Id;
                }
                return null;
            }
        }

        public string EntityInfo
        {
            get { return this.regionModel.EntityInfo; }
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

        public RegionModel DetailConnection
        {
            get { return this.GetConnectionTo(WidgetActions.Detail); }
        }

        #endregion

        #region Methods

        protected virtual T GetPropertyValue<T>(string propertyName)
        {
            if (this.regionModel.Properties.Any(x => x.Key.Code == propertyName))
            {
                var kvp = this.regionModel.Properties.First(x => x.Key.Code == propertyName);
                return (T)Convert.ChangeType(kvp.Value, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// Get the target region. If not specified, returns current region
        /// </summary>
        protected RegionModel GetConnectionTo(string action)
        {
            var connection = this.regionModel.RegionConnections.FirstOrDefault(x => x.Key == action);
            return connection.IsDefault() ? this.regionModel : connection.Value;
        }

        #endregion
    }
}
