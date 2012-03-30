using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Common.Framework.System
{
    public class RegionModel : AbstractModelGenericWithActive<Region, long>
    {
        public WidgetModel Widget
        {
            get { return new WidgetModel(base.Entity.Widget); }
        }

        public ReadOnlyCollection<KeyValuePair<string, RegionModel>> RegionConnections
        {
            get
            {
                var listConnections = base.Entity.RegionConnections.Select(x => new KeyValuePair<string, RegionModel>(x.Action, new RegionModel(x.To))).ToList();
                return new ReadOnlyCollection<KeyValuePair<string, RegionModel>>(listConnections);
            }
        }

        public ReadOnlyCollection<KeyValuePair<string, string>> Properties
        {
            get
            {
                var listProperties = base.Entity.Settings.Select(x => new KeyValuePair<string, string>(x.WidgetProperty.Code, x.Value)).ToList();
                return new ReadOnlyCollection<KeyValuePair<string, string>>(listProperties);
            }
        }

        #region Properties

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

        public int? Position
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public RegionModel()
            : base()
        {
        }

        public RegionModel(Region entity)
            : base(entity)
        {
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Position = entity.Position;
        }

        #endregion
    }
}
