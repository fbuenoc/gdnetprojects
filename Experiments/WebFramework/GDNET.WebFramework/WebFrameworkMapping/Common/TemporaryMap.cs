using System;
using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class TemporaryMap : AbstractEntityMapping<Temporary, Guid>, INHibernateMapping
    {
        public TemporaryMap()
            : base(Generators.Assigned)
        {
            base.Property(e => e.Text);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.EncryptionType, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingConstants.Temporary.EncryptionTypeId);
                m.Cascade(Cascade.None);
            });
        }
    }
}
