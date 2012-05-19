using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Data.Common.Repositories;
using WebFramework.Data.Common.Specifications;
using WebFramework.Data.System.Repositories;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.Common;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.NHibernate
{
    public sealed class FrameworkRepositories : DomainRepositories
    {
        private ISessionStrategy sessionStrategy;
        private Dictionary<Type, object> cacheWidgetRepositories = new Dictionary<Type, object>();

        public FrameworkRepositories(ISessionStrategy sessionStrategy)
        {
            this.sessionStrategy = sessionStrategy;
            base.Initialize(this);
        }

        protected override T GetWidgetRepositoryInternal<T>(Widget w)
        {
            if (cacheWidgetRepositories.ContainsKey(typeof(T)))
            {
                return (T)cacheWidgetRepositories[typeof(T)];
            }

            int counter = 0;
            while (true)
            {
                if (w.Properties.Any(x => x.Code == string.Format(CommonConstants.WidgetPropertyRepositoryAssemblyName, counter)))
                {
                    string repositoryAssemblyName = w.Properties.First(x => x.Code == string.Format(CommonConstants.WidgetPropertyRepositoryAssemblyName, counter)).Value;
                    string repositoryClassName = w.Properties.First(x => x.Code == string.Format(CommonConstants.WidgetPropertyRepositoryClassName, counter)).Value;

                    if (typeof(T).FullName == repositoryClassName)
                    {
                        Assembly asm = Assembly.Load(repositoryAssemblyName);
                        var type = asm.GetType(repositoryClassName, true);

                        T repositoryInstance = (T)Activator.CreateInstance(type, this.sessionStrategy);
                        cacheWidgetRepositories.Add(typeof(T), repositoryInstance);

                        return repositoryInstance;
                    }
                    else
                    {
                        counter += 1;
                    }
                }
                else
                {
                    break;
                }
            }

            return default(T);
        }

        protected override IApplicationRepository GetApplicationRepository()
        {
            IApplicationRepository repository = new ApplicationRepository(this.sessionStrategy);
            repository.Specification = new ApplicationSpecification();

            return repository;
        }

        protected override IContentAttributeRepository GetContentAttributeRepository()
        {
            IContentAttributeRepository repository = new ContentAttributeRepository(this.sessionStrategy);
            repository.Specification = new ContentAttributeSpecification();

            return repository;
        }

        protected override IContentItemRepository GetContentItemRepository()
        {
            IContentItemRepository repository = new ContentItemRepository(this.sessionStrategy);
            repository.Specification = new ContentItemSpecification();

            return repository;
        }

        protected override IContentTypeRepository GetContentTypeRepository()
        {
            IContentTypeRepository repository = new ContentTypeRepository(this.sessionStrategy);
            repository.Specification = new ContentTypeSpecification();

            return repository;
        }

        protected override ICultureRepository GetCultureRepository()
        {
            ICultureRepository repository = new CultureRepository(this.sessionStrategy);
            repository.Specification = new CultureSpecification();
            return repository;
        }

        protected override IListValueRepository GetRepositoryListValue()
        {
            IListValueRepository repository = new ListValueRepository(this.sessionStrategy);
            repository.Specification = new ListValueSpecification();
            return repository;
        }

        protected override ITemporaryRepository GetTemporaryRepository()
        {
            ITemporaryRepository repository = new TemporaryRepository(this.sessionStrategy);
            repository.Specification = new TemporarySpecification();
            return repository;
        }

        protected override ITranslationRepository GetTranslationRepository()
        {
            ITranslationRepository repository = new TranslationRepository(this.sessionStrategy);
            repository.Specification = new TranslationSpecification();

            return repository;
        }

        protected override IPageRepository GetPageRepository()
        {
            IPageRepository repository = new PageRepository(this.sessionStrategy);
            return repository;
        }

        protected override IWidgetRepository GetWidgetRepository()
        {
            IWidgetRepository repository = new WidgetRepository(this.sessionStrategy);
            return repository;
        }

        protected override IZoneRepository GetZoneRepository()
        {
            IZoneRepository repository = new ZoneRepository(this.sessionStrategy);
            return repository;
        }

        protected override IRepositoryAssistant GetRepositoryAssistant()
        {
            return this.sessionStrategy;
        }
    }
}
