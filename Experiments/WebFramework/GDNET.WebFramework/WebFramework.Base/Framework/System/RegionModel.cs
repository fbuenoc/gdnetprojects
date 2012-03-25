using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Base.Framework.System
{
    public class RegionModel : AbstractModelGeneric<Region, long>
    {
        public WidgetModel Widget
        {
            get { return new WidgetModel(base.Entity.Widget); }
        }

        public ReadOnlyCollection<KeyValuePair<string, string>> Properties
        {
            get
            {
                var listProperties = base.Entity.Settings.Select(x => new KeyValuePair<string, string>(x.WidgetProperty.Code, x.Value)).ToList();
                return new ReadOnlyCollection<KeyValuePair<string, string>>(listProperties);
            }
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

        public int? Position
        {
            get;
            set;
        }

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
    }
}
