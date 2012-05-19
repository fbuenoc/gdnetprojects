using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Mapping.Base;
using WebFramework.Widgets.Domain.ArticleWg;


namespace WebFramework.Widgets.Mapping.ArticleWg
{
    public class ArticleMap : EntityBaseMapping<Article, long>, INHibernateMapping
    {
        public ArticleMap()
            : base(Generators.Native)
        {
            base.Table("w_" + typeof(Article).Name);
            base.Property(e => e.Title);
            base.Property(e => e.Description);
            base.Property(e => e.FullContent);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
        }
    }
}
