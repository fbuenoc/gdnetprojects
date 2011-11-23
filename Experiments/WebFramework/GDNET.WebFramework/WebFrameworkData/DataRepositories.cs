using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData
{
    public abstract class DataRepositories : IDomainRepositories
    {
        private static IDomainRepositories _instance;

        protected void Initialize(IDomainRepositories instance)
        {
            _instance = instance;
        }

        public static IRepositoryTranslation Translation
        {
            get { return _instance.GetRepositoryTranslation(); }
        }

        public static IRepositoryCategory Category
        {
            get { return _instance.GetRepositoryCategory(); }
        }

        public static IRepositoryTemporary Temporary
        {
            get { return _instance.GetRepositoryTemporary(); }
        }

        #region IDataRepositories Members

        public abstract IRepositoryTranslation GetRepositoryTranslation();
        public abstract IRepositoryCategory GetRepositoryCategory();
        public abstract IRepositoryTemporary GetRepositoryTemporary();

        #endregion

    }
}
