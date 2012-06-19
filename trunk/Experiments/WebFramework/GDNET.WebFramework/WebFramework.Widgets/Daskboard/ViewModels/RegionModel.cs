using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Domain.System;
using WebFramework.Widgets.Daskboard.Base;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public class RegionModel : ModelEntityWithLifeCycleBase<Region, long>
    {
        private ZoneModel zone = default(ZoneModel);
        private WidgetModel widget = default(WidgetModel);

        public WidgetModel Widget
        {
            get
            {
                if (base.Entity != null && base.Entity.Widget != null)
                {
                    widget = new WidgetModel(base.Entity.Widget);
                }
                return widget;
            }
        }

        public string WidgetSelection
        {
            get;
            set;
        }

        public ZoneModel Zone
        {
            get
            {
                if (base.Entity != null && base.Entity.Zone != null)
                {
                    zone = new ZoneModel(base.Entity.Zone);
                }
                return zone;
            }
        }

        public ReadOnlyCollection<KeyValuePair<string, RegionModel>> RegionConnections
        {
            get
            {
                var listConnections = base.Entity.RegionConnections.Select(x => new KeyValuePair<string, RegionModel>(x.Action, new RegionModel(x.To))).ToList();
                return new ReadOnlyCollection<KeyValuePair<string, RegionModel>>(listConnections);
            }
        }

        public ReadOnlyCollection<KeyValuePair<WidgetPropertyModel, string>> Properties
        {
            get
            {
                var listProperties = base.Entity.Settings.Select(x => new KeyValuePair<WidgetPropertyModel, string>(new WidgetPropertyModel(x.WidgetProperty), x.Value)).ToList();
                return new ReadOnlyCollection<KeyValuePair<WidgetPropertyModel, string>>(listProperties);
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

        #region Methods

        public void InitializeZone(Zone zoneEntity)
        {
            this.zone = new ZoneModel(zoneEntity);
        }

        #endregion
    }
}
