using GDNET.NHibernate.SessionManagement;
using KnowledgeSharing.Data.Repositories;
using KnowledgeSharing.Domain;
using KnowledgeSharing.Domain.Repositories;

namespace KnowledgeSharing.Data
{
    public sealed class AppDataRepositories : AppDomainRepositories
    {
        private INHibernateRepositoryStrategy repositoryStrategy = null;

        public AppDataRepositories(INHibernateRepositoryStrategy strategy)
        {
            this.repositoryStrategy = strategy;
            base.Initialize(this);
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            return new ContentItemRepository(this.repositoryStrategy);
        }
    }
}
