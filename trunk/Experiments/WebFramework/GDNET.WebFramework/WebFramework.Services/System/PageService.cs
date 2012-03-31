using System.Linq;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Services;
using WebFramework.Domain.System;

namespace WebFramework.Services.System
{
    public sealed class PageService : IPageService
    {
        public Page GetDefaultPage(Application application, Culture culture)
        {
            var properties = new string[] { MetaInfos.PageMeta.Application, MetaInfos.PageMeta.Culture, MetaInfos.PageMeta.IsDefault };
            var values = new object[] { application, culture, true };
            var listOfPages = DomainRepositories.Page.FindByProperties(properties, values);

            return listOfPages.FirstOrDefault();
        }
    }
}
