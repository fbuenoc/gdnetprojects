﻿using System;
using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class TemporaryMap : AbstractEntityMapping<Temporary, Guid>, INHibernateMapping
    {
        public TemporaryMap()
            : base(Generators.Assigned)
        {
            base.Property(e => e.Text);
            base.ManyToOne(e => e.EncryptionType, m =>
            {
                m.Cascade(Cascade.None);
                m.Lazy(LazyRelation.Proxy);
                m.Column(TemporaryMeta.EncryptionTypeId);
            });
        }
    }
}
