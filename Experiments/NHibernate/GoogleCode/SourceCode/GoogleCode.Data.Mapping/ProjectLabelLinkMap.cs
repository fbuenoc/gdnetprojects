using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleCode.Core.Domain;
using NHibernate.Mapping.ByCode;

namespace GoogleCode.Data.Mapping
{
    public class ProjectLabelLinkMap : MappingBase<ProjectLabelLink, long>
    {
        public ProjectLabelLinkMap()
        {
            base.Property(link => link.CreatedDate);

            base.ManyToOne(link => link.Project, map =>
            {
                map.Column("ProjectId");
                map.NotNullable(true);
            });
            base.ManyToOne(link => link.Label, map =>
            {
                map.Column("LabelId");
                map.NotNullable(true);
            });
        }
    }
}
