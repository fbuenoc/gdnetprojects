using WebFramework.Domain.Common;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Services
{
    public interface IPageService
    {
        Page GetDefaultPage(Application application, Culture culture);
    }
}
