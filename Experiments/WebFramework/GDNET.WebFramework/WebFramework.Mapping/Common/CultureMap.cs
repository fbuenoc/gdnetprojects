using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Domain.Common;

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
