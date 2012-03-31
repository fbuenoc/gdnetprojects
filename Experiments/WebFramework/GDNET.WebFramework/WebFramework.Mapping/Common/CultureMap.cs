using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class CultureMap : EntityWithActiveMapping<Culture, int>, INHibernateMapping
    {
        public CultureMap()
            : base(Generators.Native)
        {
            base.Property(e => e.CultureCode);
            base.Property(e => e.IsDefault);
        }
    }
}
