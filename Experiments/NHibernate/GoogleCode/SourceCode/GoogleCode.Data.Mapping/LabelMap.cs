using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GoogleCode.Core.Domain;
using NHibernate.Mapping.ByCode;

namespace GoogleCode.Data.Mapping
{
    public class LabelMap : MappingBase<Label, int>
    {
        public LabelMap()
        {
            base.Property(label => label.Name);

            base.Bag(label => label.Projects, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table("ProjectLabelLink");
                cm.Key(km => km.Column("LabelId"));
            }, map =>
            {
                map.ManyToMany(mmm => mmm.Column("ProjectId"));
            });
        }
    }
}
