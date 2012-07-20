﻿using GDNET.Domain.Base;
using GDNET.Domain.Repositories.Content;
using GDNET.Domain.Repositories.System;

namespace GDNET.Domain.Repositories
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

        public static IContentItemRepository ContentItem
        {
            get { return _instance.GetContentItemRepository(); }
        }

        public static IRepositoryManager RepositoryManager
        {
            get { return _instance.GetRepositoryManager(); }
        }

        protected abstract IUserRepository GetUserRepository();
        protected abstract IContentItemRepository GetContentItemRepository();
        protected abstract IRepositoryManager GetRepositoryManager();
    }
}