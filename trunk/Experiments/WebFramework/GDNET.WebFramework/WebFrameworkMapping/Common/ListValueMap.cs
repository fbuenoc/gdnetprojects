using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ListValueMap : EntityFullControlMappingBase<ListValue, long>
    {
        public ListValueMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Name);
            base.Property(e => e.CustomValue);
            base.Property(e => e.Position);

            base.ManyToOne(e => e.Description, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ListValueMeta.DescriptionTranslationId);
            });
            base.ManyToOne(e => e.Application, m =>
            {
                m.Cascade(Cascade.None);
                m.Column(ListValueMeta.ApplicationId);
            });
            base.ManyToOne(e => e.Parent, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ListValueMeta.ParentId);
            });

            base.Bag(e => e.SubValues, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(ListValueMeta.ParentId));
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
