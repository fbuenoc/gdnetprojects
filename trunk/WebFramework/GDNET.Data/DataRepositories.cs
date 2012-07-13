using GDNET.Data.System;
using GDNET.Domain;
using GDNET.Domain.Base;
using GDNET.Domain.System.Repositories;
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
            return new UserRepository(this.sessionStrategy);
        }

        protected override IRepositoryManager GetRepositoryManager()
        {
            return this.sessionStrategy;
        }
    }
}
