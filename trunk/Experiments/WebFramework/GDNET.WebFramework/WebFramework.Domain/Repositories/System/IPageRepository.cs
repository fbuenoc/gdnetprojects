using GDNET.Common.Data;
using WebFramework.Domain.System;

namespace WebFramework.Domain.Repositories.System
{
    public interface IPageRepository : IRepositoryWithActiveBase<Page, long>
    {
        Page GetByUniqueName(string uniqueName);
    }
}
