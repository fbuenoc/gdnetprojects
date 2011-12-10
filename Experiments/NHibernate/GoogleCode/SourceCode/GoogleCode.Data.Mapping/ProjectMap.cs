﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GoogleCode.Core.Domain;
using NHibernate.Mapping.ByCode;

namespace GoogleCode.Data.Mapping
{
    public class ProjectMap : MappingBase<Project, long>
    {
        public ProjectMap()
        {
            base.Property(project => project.Name);
            base.Property(project => project.Homepage);
            base.Property(project => project.LogoUrl);
            base.Property(project => project.Activity);
            base.Property(project => project.Description);
            base.Property(project => project.LastUpdate);

            base.Bag(project => project.Links, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table("ProjectLabelLink");
                cm.Key(km =>
                {
                    km.Column("ProjectId");
                });
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}