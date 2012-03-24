using System;
using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class TemporaryMap : AbstractEntityWithActiveMapping<Temporary, Guid>, INHibernateMapping
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
