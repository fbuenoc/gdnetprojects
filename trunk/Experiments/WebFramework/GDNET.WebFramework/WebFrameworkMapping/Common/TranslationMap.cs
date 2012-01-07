using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class TranslationMap : EntityFullControlMappingBase<Translation, long>
    {
        public TranslationMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Value, m =>
            {
                m.Lazy(true);
            });
            base.Property(e => e.IsGeneric);

            base.ManyToOne(e => e.Category, m =>
            {
                m.NotNullable(false);
                m.Column(TranslationMeta.CategoryId);
            });
            base.ManyToOne(e => e.Culture, m =>
            {
                m.NotNullable(true);
                m.Column(TranslationMeta.CultureId);
            });
        }
    }
}
