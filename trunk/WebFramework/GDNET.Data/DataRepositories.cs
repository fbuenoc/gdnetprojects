using GDNET.Data.Content;
using GDNET.Data.System;
using GDNET.Data.System.Repositories;
using GDNET.Domain.Base;
using GDNET.Domain.Repositories;
using GDNET.Domain.Repositories.Content;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;

namespace GDNET.Data
{
    public sealed class DataRepositories : DomainRepositories
    {
        private ISessionStrategy sessionStrategy = null;

        public DataRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        protected override IUserRepository GetUserRepository()
        {
            var userRepository = new UserRepository(this.sessionStrategy);
            userRepository.RepositoryGlass = new UserRepositoryGlass();

            return userRepository;
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            return new ContentItemRepository(this.sessionStrategy);
        }

        protected override IRepositoryManager GetRepositoryManager()
        {
            return this.sessionStrategy;
        }
    }
}
