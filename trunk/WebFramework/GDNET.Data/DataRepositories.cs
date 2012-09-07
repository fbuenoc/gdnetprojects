using GDNET.Data.Content;
using GDNET.Data.System;
using GDNET.Data.System.Repositories;
using GDNET.Domain.Common;
using GDNET.Domain.Repositories;
using GDNET.Domain.Repositories.Content;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data
{
    public sealed class DataRepositories : DomainRepositories
    {
        private INHibernateRepositoryStrategy repositoryStrategy = null;

        public DataRepositories(INHibernateRepositoryStrategy strategy)
        {
            this.repositoryStrategy = strategy;
            base.Initialize(this);
        }

        protected override IUserRepository GetUserRepository()
        {
            var userRepository = new UserRepository(this.repositoryStrategy);
            userRepository.RepositoryGlass = new UserRepositoryGlass();

            return userRepository;
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            return new ContentItemRepository(this.repositoryStrategy);
        }

        protected override ITranslationRepository GetTranslationRepository()
        {
            return new TranslationRepository(this.repositoryStrategy);
        }

        protected override IRepositoryStrategy GetRepositoryStrategy()
        {
            return this.repositoryStrategy;
        }

    }
}
