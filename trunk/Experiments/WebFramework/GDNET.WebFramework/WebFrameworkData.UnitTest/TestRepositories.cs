using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebFrameworkData.Common.Repositories;
using WebFrameworkData.Common.Specifications;

using WebFrameworkDomain;
using WebFrameworkDomain.Common.Repositories;
using WebFrameworkDomain.DefaultImpl;

namespace WebFrameworkData.UnitTest
{
    public sealed class TestRepositories : DomainRepositories
    {
        private IRepositoryApplication repositoryApplication = null;
        private IRepositoryContentAttribute repositoryContentAttribute = null;
        private IRepositoryContentItem repositoryContentItem = null;
        private IRepositoryContentType repositoryContentType = null;
        private IRepositoryCulture repositoryCulture = null;
        private IRepositoryListValue repositoryListValue = null;
        private IRepositoryTemporary repositoryTemporary = null;
        private IRepositoryTranslation repositoryTranslation = null;

        public TestRepositories()
        {
            base.Initialize(this);
        }

        public override IRepositoryApplication GetRepositoryApplication()
        {
            if (repositoryApplication == null)
            {
                repositoryApplication = new RepositoryApplication(NUnitBase.GetCurrentSession());
                repositoryApplication.Specification = new SpecificationApplication();
            }
            return repositoryApplication;
        }

        public override IRepositoryContentAttribute GetRepositoryContentAttribute()
        {
            if (repositoryContentAttribute == null)
            {
                repositoryContentAttribute = new RepositoryContentAttribute(NUnitBase.GetCurrentSession());
            }
            return repositoryContentAttribute;
        }

        public override IRepositoryContentItem GetRepositoryContentItem()
        {
            if (repositoryContentItem == null)
            {
                repositoryContentItem = new RepositoryContentItem(NUnitBase.GetCurrentSession());
                repositoryContentItem.Specification = new SpecificationContentItem();
            }
            return repositoryContentItem;
        }

        public override IRepositoryContentType GetRepositoryContentType()
        {
            if (repositoryContentType == null)
            {
                repositoryContentType = new RepositoryContentType(NUnitBase.GetCurrentSession());
                repositoryContentType.Specification = new SpecificationContentType();
            }
            return repositoryContentType;
        }

        public override IRepositoryCulture GetRepositoryCulture()
        {
            if (repositoryCulture == null)
            {
                repositoryCulture = new RepositoryCulture(NUnitBase.GetCurrentSession());
            }
            return repositoryCulture;
        }

        public override IRepositoryListValue GetRepositoryListValue()
        {
            if (repositoryListValue == null)
            {
                repositoryListValue = new RepositoryListValue(NUnitBase.GetCurrentSession());
                repositoryListValue.Specification = new SpecificationListValue();
            }
            return repositoryListValue;
        }

        public override IRepositoryTemporary GetRepositoryTemporary()
        {
            if (repositoryTemporary == null)
            {
                repositoryTemporary = new RepositoryTemporary(NUnitBase.GetCurrentSession());
            }
            return repositoryTemporary;
        }

        public override IRepositoryTranslation GetRepositoryTranslation()
        {
            if (repositoryTranslation == null)
            {
                repositoryTranslation = new RepositoryTranslation(NUnitBase.GetCurrentSession());
            }
            return repositoryTranslation;
        }

    }
}
