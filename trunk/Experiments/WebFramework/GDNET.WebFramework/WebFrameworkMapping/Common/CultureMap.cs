using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class CultureMap : AbstractEntityMapping<Culture, int>, INHibernateMapping
    {
        public CultureMap()
            : base(Generators.Native)
        {
            base.Property(e => e.CultureCode);
            base.Property(e => e.IsDefault);
        }
    }
}
