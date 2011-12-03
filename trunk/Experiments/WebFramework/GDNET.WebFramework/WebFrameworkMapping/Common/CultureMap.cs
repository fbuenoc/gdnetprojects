using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class CultureMap : EntityActiveMappingBase<Culture, int>
    {
        public CultureMap()
            : base(Generators.Native)
        {
            base.Property(e => e.CultureCode);
            base.Property(e => e.IsDefault);
        }
    }
}
