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

        public ReadOnlyCollection<KeyValuePair<string, string>> Properties
        {
            get { return this.regionModel.Properties; }
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

        protected T GetPropertyValue<T>(string propertyName)
        {
            if (this.regionModel.Properties.Any(x => x.Key == propertyName))
            {
                var kvp = this.regionModel.Properties.First(x => x.Key == propertyName);
                return (T)Convert.ChangeType(kvp.Value, typeof(T));
            }

            return default(T);
        }

        protected RegionModel GetConnectionTo(string action)
        {
            var connection = this.regionModel.RegionConnections.FirstOrDefault(x => x.Key == action);
            return connection.IsDefault() ? null : connection.Value;
        }
    }
}
