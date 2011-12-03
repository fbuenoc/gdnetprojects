using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ApplicationMap : EntityFullControlMappingBase<Application, long>
    {
        public ApplicationMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.Name, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ApplicationMeta.NameTranslationId);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ApplicationMeta.DescriptionTranslationId);
            });
            base.ManyToOne(e => e.Category, m =>
            {
                m.Cascade(Cascade.None);
                m.Column(ApplicationMeta.CategoryId);
            });

            base.Property(e => e.RootUrl);
        }
    }
}
