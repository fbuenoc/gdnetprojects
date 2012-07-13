using GDNET.Domain.Base;
using GDNET.Domain.System.Repositories;

namespace GDNET.Domain
{
    public abstract class DomainRepositories
    {
        private static DomainRepositories _instance;

        protected void Initialize(DomainRepositories instance)
        {
            _instance = instance;
        }

        public static IUserRepository User
        {
            get { return _instance.GetUserRepository(); }
        }

        public static IRepositoryManager RepositoryManager
        {
            get { return _instance.GetRepositoryManager(); }
        }

        protected abstract IUserRepository GetUserRepository();
        protected abstract IRepositoryManager GetRepositoryManager();
    }
}
