using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Mapping.Base;
using WebFramework.Widgets.Domain.FileWg;
using WebFramework.Widgets.Mapping.Constants;

namespace WebFramework.Widgets.Mapping.FileWg
{
    public class FileContentMap : EntityBaseMapping<FileContent, long>, INHibernateMapping
    {
        public FileContentMap()
            : base(Generators.Native)
        {
            base.Table("w_" + typeof(FileContent).Name);
            base.Property(e => e.Name);
            base.Property(e => e.Title);
            base.Property(e => e.Description);
            base.Property(e => e.Base64Content);

            base.ManyToOne(e => e.Type, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(WidgetsMappingConstants.ColumnTypeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.Bag(x => x.AttachedRegions, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Cascade(Cascade.None);
                cm.Table(WidgetsMappingConstants.TableFileRegion);
                cm.Key(k => { k.Column(WidgetsMappingConstants.ColumnFileId); });
            }, m =>
            {
                m.ManyToMany(mm =>
                {
                    mm.Column(WidgetsMappingConstants.ColumnRegionId);
                });
            });
        }
    }
}
